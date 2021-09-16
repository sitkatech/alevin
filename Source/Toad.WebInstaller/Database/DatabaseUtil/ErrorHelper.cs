using System;
using System.IO;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    enum ERROR_CODES
    {
        ASSERTION_FAILED = 513,
        POST_CONDITION_ASSERTION_FAILED = 514,
        PRE_CONDITION_ASSERTION_FAILED = 515,
        SCHEMA_COMPARISON_FAILED = 516,
        SYNCH_TEXT_OBJECTS_FAILED = 517,
        DLL_COMPILE_FAILED = 518,
        PROCESS_TERMINATE_FAILED = 519,
        DATABASE_OBJECTS_WITH_SET_ANSI_NULLS_OFF = 520
    }


    /// <summary>
    /// Summary description for ErrorHelper.
    /// </summary>
    public abstract class ErrorHelper
    {
        public static string GetMessageFromException(System.Exception e)
        {
            string errorInfo = String.Format("Message: {0}\nType: {1}\nSource: {2}\nStack Trace: {3}", e.Message, e.GetType().ToString(), e.Source, e.StackTrace);
			
			// Get the inner exception details also
			if (e.InnerException != null)
			{
				System.Exception innerException = e.InnerException;

				string errorInfoInner = ErrorHelper.GetMessageFromException(innerException);

				errorInfo = String.Format("{0}\n\nInner Exception{1}", errorInfo, errorInfoInner);
			}

            return errorInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnAssert"></param>
        public static void Assert(bool blnAssert)
        {
            ErrorHelper.Assert(blnAssert,"");
        }
        public static void Assert(bool blnAssert, string strAssertError)
        {
            if (blnAssert == false)
            {
                throw new System.Exception("modErrorHandler.Assert Failed: " + strAssertError);
            }
        }
        public static void AssertPostCondition(bool blnAssert)
        {
            ErrorHelper.AssertPostCondition(blnAssert,"");
        }
        public static void AssertPostCondition(bool blnAssert, string strAssertError)
        {
            if (blnAssert == false)
            {
                throw new System.Exception("Post Condition Failed: " + strAssertError);
            }
        }
        public static void AssertPreCondition(bool blnAssert)
        {
            ErrorHelper.AssertPreCondition(blnAssert,"");
        }
        public static void AssertPreCondition(bool blnAssert, string strAssertError)
        {
            if (blnAssert == false)
            {
                throw new System.Exception("Pre Condition Failed: " + strAssertError);
            }
        }
        public static void logEvent(string strFile, string strLogText)
        {
            bool blnAppend = true;
            StreamWriter strm = new StreamWriter(strFile, blnAppend);
            strm.WriteLine(strLogText);
            strm.Close();
        }


    }
}
