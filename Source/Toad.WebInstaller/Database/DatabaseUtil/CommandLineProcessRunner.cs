using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    public class ProcessResult
    {
        public readonly int ReturnCode;
        public readonly string StandardOutput;
        public readonly string StandardError;
        public readonly string StandardErrorAndStandardOutput;

        public ProcessResult(int returnCode, string standardOutput, string standardError, string standardErrorAndStandardOutput)
        {
            ReturnCode = returnCode;
            StandardOutput = standardOutput;
            StandardError = standardError;
            StandardErrorAndStandardOutput = standardErrorAndStandardOutput;
        }
    }

    public class CommandLineProcess
    {
        private readonly DirectoryInfo _workingDirectory;
        private readonly FileInfo _executibleFile;
        private readonly string[] _unencodedCommandLineArguments;
        private static readonly TimeSpan _maxTimeout = TimeSpan.FromDays(10);
        private ProcessResult _lastProcessResult;

        public ProcessResult LastProcessResult
        {
            get { return _lastProcessResult; }
        }

        public CommandLineProcess(DirectoryInfo workingDirectory, FileInfo executibleFile, string[] unencodedCommandLineArguments)
        {
            _workingDirectory = workingDirectory;
            _executibleFile = executibleFile;
            _unencodedCommandLineArguments = unencodedCommandLineArguments;
        }

        public FileInfo ProgramFile
        {
            get { return _executibleFile; }
        }

        public DirectoryInfo WorkingDirectory
        {
            get { return _workingDirectory; }
        }

        public string CommandLineArgumentsAsString
        {
            get
            {
                var argumentsAsString = String.Join(" ", _unencodedCommandLineArguments.Select(EncodeArgumentForCommandLine).ToList());
                return argumentsAsString;
            }
        }

        /// <summary>
        /// A string that one could paste onto a command line to emulate what this code is doing
        /// </summary>
        public string AsStringRepresentingCommandLine
        {
            get { return String.Format("cd /d {0} && {1} {2}", EncodeArgumentForCommandLine(_workingDirectory.FullName), EncodeArgumentForCommandLine(_executibleFile.FullName), CommandLineArgumentsAsString); }
        }

        public ProcessResult RunProcess(CommandLineOutputCaptureOptionsFlag captureOptionsFlag)
        {
            _lastProcessResult = RunProcess(_workingDirectory.FullName, _executibleFile.FullName, CommandLineArgumentsAsString, null, captureOptionsFlag);
            return _lastProcessResult;
        }

        private static ProcessResult RunProcess(string workingDirectory, string exeFileName, string argumentsAsString, int? maxTimeoutMs, CommandLineOutputCaptureOptionsFlag captureOptionsFlag)
        {
            // Start the indicated program and wait for it
            // to finish, hiding while we wait.
            ProcessResult r;
            using (var processWrapper = new KillOnDisposeProcessWrapper(new Process {StartInfo = new ProcessStartInfo(exeFileName, argumentsAsString)}))
            {
                if (!String.IsNullOrEmpty(workingDirectory))
                {
                    processWrapper.Process.StartInfo.WorkingDirectory = workingDirectory;
                }
                var outputSink = new ProcessStreamReader(captureOptionsFlag);
                processWrapper.Process.StartInfo.UseShellExecute = false;
                processWrapper.Process.StartInfo.RedirectStandardOutput = true;
                processWrapper.Process.StartInfo.RedirectStandardError = true;
                processWrapper.Process.StartInfo.CreateNoWindow = true;
                processWrapper.Process.OutputDataReceived += outputSink.ReceiveStdOut;
                processWrapper.Process.ErrorDataReceived += outputSink.ReceiveStdErr;

                var processDebugInfo = String.Format("Process Details:\r\n\"{0}\" {1}\r\nWorking Directory: {2}", exeFileName, argumentsAsString, workingDirectory);
                try
                {
                    processWrapper.Process.Start();
                }
                catch (Exception e)
                {
                    var message = String.Format("Program {0} got an exception on process start.\r\nException message: {1}\r\n{2}", Path.GetFileName(exeFileName), e.Message, processDebugInfo);
                    throw new Exception(message, e);
                }

                processWrapper.Process.BeginOutputReadLine();
                processWrapper.Process.BeginErrorReadLine();

                var processTimeoutPeriod = (maxTimeoutMs.HasValue) ? TimeSpan.FromMilliseconds(maxTimeoutMs.Value) : _maxTimeout;
                var hasExited = processWrapper.Process.WaitForExit(Convert.ToInt32(processTimeoutPeriod.TotalMilliseconds));

                if (!hasExited)
                {
                    processWrapper.Process.Kill();
                }

                // TODO: Fix this so it works without a hacky "Sleep", right now this hack waits for the output to trickle in. The asychronous reads of STDERR and STDOUT may not yet be complete (run unit test under debugger for example) even though the process has exited. -MF & ASW 11/21/2011
                Thread.Sleep(TimeSpan.FromSeconds(.25));

                if (!hasExited)
                {
                    var message = String.Format("Program {0} did not exit within timeout period {1} and was terminated.\r\n{2}\r\nOutput:\r\n{3}", Path.GetFileName(exeFileName), processTimeoutPeriod,
                                                processDebugInfo, outputSink.StdOutAndStdErr);
                    throw new Exception(message);
                }

                r = new ProcessResult(processWrapper.Process.ExitCode, outputSink.StdOut, outputSink.StdErr, outputSink.StdOutAndStdErr);
            }
            return r;
        }

        /// <summary>
        /// Handles the reading of standard out and standard error
        /// </summary>
        private class ProcessStreamReader
        {
            private readonly CommandLineOutputCaptureOptionsFlag _captureOptionsFlag;

            private readonly object _outputLock = new object();
            private readonly StringBuilder _standardErrorAndStandardOutput = new StringBuilder();
            private readonly StringBuilder _standardError = new StringBuilder();
            private readonly StringBuilder _standardOutput = new StringBuilder();

            public ProcessStreamReader(CommandLineOutputCaptureOptionsFlag captureOptionsFlag)
            {
                _captureOptionsFlag = captureOptionsFlag;
            }

            private void RecordOutput(string message)
            {
                lock (_outputLock)
                {
                    _standardErrorAndStandardOutput.AppendFormat("{0}\r\n", message);
                }
            }

            public void ReceiveStdOut(object sender, DataReceivedEventArgs e)
            {
                lock (_outputLock)
                {
                    var message = string.Format("[stdout] {0}", e.Data);
                    if ((_captureOptionsFlag & CommandLineOutputCaptureOptionsFlag.CaptureOutputInString) == CommandLineOutputCaptureOptionsFlag.CaptureOutputInString)
                    {
                        _standardOutput.AppendFormat("{0}\r\n", e.Data);
                        RecordOutput(message);
                    }
                    if ((_captureOptionsFlag & CommandLineOutputCaptureOptionsFlag.PassThroughToConsole) == CommandLineOutputCaptureOptionsFlag.PassThroughToConsole)
                    {
                        Console.Out.WriteLine(e.Data);
                    }
                }
            }

            public void ReceiveStdErr(object sender, DataReceivedEventArgs e)
            {
                lock (_outputLock)
                {
                    var message = string.Format("[stderr] {0}", e.Data);
                    if ((_captureOptionsFlag & CommandLineOutputCaptureOptionsFlag.CaptureOutputInString) == CommandLineOutputCaptureOptionsFlag.CaptureOutputInString)
                    {
                        _standardError.AppendFormat("{0}\r\n", e.Data);
                        RecordOutput(message);
                    }
                    if ((_captureOptionsFlag & CommandLineOutputCaptureOptionsFlag.PassThroughToConsole) == CommandLineOutputCaptureOptionsFlag.PassThroughToConsole)
                    {
                        Console.Error.WriteLine(e.Data);
                    }
                }
            }

            public string StdOutAndStdErr
            {
                get
                {
                    lock (_outputLock)
                    {
                        return _standardErrorAndStandardOutput.ToString();
                    }
                }
            }

            public string StdOut
            {
                get
                {
                    lock (_outputLock)
                    {
                        return _standardOutput.ToString();
                    }
                }
            }

            public string StdErr
            {
                get
                {
                    lock (_outputLock)
                    {
                        return _standardError.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Encode a command line argument
        /// </summary>
        private static string EncodeArgumentForCommandLine(string unencodedCommandLineArgument)
        {
            // We should be escaping command line arguments in C# directly, taking an string[] args here and doing the encoding inside
            // http://blogs.msdn.com/b/twistylittlepassagesallalike/archive/2011/04/23/everyone-quotes-arguments-the-wrong-way.aspx
            // http://stackoverflow.com/questions/5510343/escape-command-line-arguments-in-c-sharp
            // http://stackoverflow.com/questions/13796722/canonical-solution-for-escaping-net-command-line-arguments
            // http://msdn.microsoft.com/en-us/library/17w5ykft.aspx

            // void
            //ArgvQuote (
            //    const std::wstring& Argument,
            //    std::wstring& CommandLine,
            //    bool Force
            //    )
            //Routine Description:
            //    This routine appends the given argument to a command line such
            //    that CommandLineToArgvW will return the argument string unchanged.
            //    Arguments in a command line should be separated by spaces; this
            //    function does not add these spaces.
            //Arguments:
            //    Argument - Supplies the argument to encode.
            //    CommandLine - Supplies the command line to which we append the encoded argument string.
            //    Force - Supplies an indication of whether we should quote
            //            the argument even if it does not contain any characters that would
            //            ordinarily require quoting.
            //Return Value:
            //    None.
            //Environment:
            //    Arbitrary.
            //    //
            //    // Unless we're told otherwise, don't quote unless we actually
            //    // need to do so --- hopefully avoid problems if programs won't
            //    // parse quotes properly
            //    //
            //    if (Force == false &&
            //        Argument.empty () == false &&
            //        Argument.find_first_of (L" \t\n\v\"") == Argument.npos)
            //    {
            //        CommandLine.append (Argument);
            //    }
            //    else {
            //        CommandLine.push_back (L'"');
            //        for (auto It = Argument.begin () ; ; ++It) {
            //            unsigned NumberBackslashes = 0;
            //            while (It != Argument.end () && *It == L'\\') {
            //                ++It;
            //                ++NumberBackslashes;
            //            }
            //            if (It == Argument.end ()) {
            //                //
            //                // Escape all backslashes, but let the terminating
            //                // double quotation mark we add below be interpreted
            //                // as a metacharacter.
            //                //
            //                CommandLine.append (NumberBackslashes * 2, L'\\');
            //                break;
            //            }
            //            else if (*It == L'"') {
            //                //
            //                // Escape all backslashes and the following
            //                // double quotation mark.
            //                //
            //                CommandLine.append (NumberBackslashes * 2 + 1, L'\\');
            //                CommandLine.push_back (*It);
            //            }
            //            else {
            //                //
            //                // Backslashes aren't special here.
            //                //
            //                CommandLine.append (NumberBackslashes, L'\\');
            //                CommandLine.push_back (*It);
            //            }
            //        }
            //        CommandLine.push_back (L'"');
            //    }
            //}

            // Parsing C++ Command-Line Arguments
            // http://msdn.microsoft.com/en-us/library/17w5ykft.aspx
            // Microsoft C/C++ startup code uses the following rules when interpreting arguments given on the operating system command line: 
            // • Arguments are delimited by white space, which is either a space or a tab.
            // • The caret character (^) is not recognized as an escape character or delimiter. The character is handled completely by the command-line parser in the operating system before being passed to the argv array in the program.
            // • A string surrounded by double quotation marks ("string") is interpreted as a single argument, regardless of white space contained within. A quoted string can be embedded in an argument.
            // • A double quotation mark preceded by a backslash (\") is interpreted as a literal double quotation mark character (").
            // • Backslashes are interpreted literally, unless they immediately precede a double quotation mark.
            // • If an even number of backslashes is followed by a double quotation mark, one backslash is placed in the argv array for every pair of backslashes, and the double quotation mark is interpreted as a string delimiter.
            // • If an odd number of backslashes is followed by a double quotation mark, one backslash is placed in the argv array for every pair of backslashes, and the double quotation mark is "escaped" by the remaining backslash, causing a literal double quotation mark (") to be placed in argv.


            var charactersThatRequireEncodingRegex = new Regex("[ \t\r\n\v]");
            if (!charactersThatRequireEncodingRegex.IsMatch(unencodedCommandLineArgument))
            {
                return unencodedCommandLineArgument;
            }

            // We must surround with DQUOTE, but first handle special BACKSLASH and embedded DQUOTE stuff
            const char backslash = '\\';
            var encodedArgument = String.Empty;
            for (var i = 0; ; i++)
            {
                var numberOfBackslashes = 0;

                // When we hit a streak of backslashes, stop processing until we reach the end of the streak
                while (i < unencodedCommandLineArgument.Length && unencodedCommandLineArgument[i] == backslash)
                {
                    ++i;
                    ++numberOfBackslashes;
                }

                // If we're now at the end of the entire argument string...
                if (i == unencodedCommandLineArgument.Length)
                {
                    // Escape all backslashes, but let the terminating DQUOTE mark we add below be interpreted as a metacharacter not part of the actual argument
                    // • If an even number of backslashes is followed by a double quotation mark, one backslash is placed in the argv array for every pair of backslashes, and the double quotation mark is interpreted as a string delimiter
                    encodedArgument += new string(backslash, numberOfBackslashes * 2);
                    break;
                }

                // If we're now at a DQUOTE in the argument string...
                if (unencodedCommandLineArgument[i] == '"')
                {
                    // Escape all backslashes and the following DQUOTE
                    // • If an odd number of backslashes is followed by a double quotation mark, one backslash is placed in the argv array for every pair of backslashes, and the double quotation mark is "escaped" by the remaining backslash, causing a literal double quotation mark (") to be placed in argv
                    encodedArgument += new string(backslash, numberOfBackslashes * 2 + 1);
                    encodedArgument += unencodedCommandLineArgument[i];
                }
                else
                {
                    // Backslashes aren't special here, put them back in place and carry on
                    encodedArgument += new string(backslash, numberOfBackslashes);
                    encodedArgument += unencodedCommandLineArgument[i];
                }
            }
            // Surround the entire argument with DQUOTE
            return String.Format("\"{0}\"", encodedArgument);
        }

        [Flags]
        public enum CommandLineOutputCaptureOptionsFlag 
        {
            PassThroughToConsole,
            CaptureOutputInString
        }
    }

    public class KillOnDisposeProcessWrapper : IDisposable
    {
        private Process _processToKillOnDisposeIfStillRunning;
        private bool _isDisposed;

        public KillOnDisposeProcessWrapper(Process processToKillOnDisposeIfStillRunning)
        {
            _processToKillOnDisposeIfStillRunning = processToKillOnDisposeIfStillRunning;
        }

        public Process Process
        {
            get
            {
                if(_isDisposed) throw new ObjectDisposedException("It is already disposed");
                return _processToKillOnDisposeIfStillRunning;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed && _processToKillOnDisposeIfStillRunning != null)
            {
                if (!_processToKillOnDisposeIfStillRunning.HasExited)
                {
                    _processToKillOnDisposeIfStillRunning.Kill();
                }
            }
            _processToKillOnDisposeIfStillRunning = null;
            _isDisposed = true;
        }
    }
}