using System.IO;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class FbmsInvoiceStageImportsHelper
    {
        public static FbmsInvoiceStageImports LoadFromXlsFile(Stream stream, int headerRowOffset)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(stream, FbmsInvoiceStageImports.SheetName, FbmsInvoiceStageImports.UseExistingSheetNameIfSingleSheetFound, headerRowOffset);
            return FbmsInvoiceStageImports.LoadFromXlsFile(dataTable);
        }

        public static FbmsInvoiceStageImports LoadFromXlsFile(FileInfo file, int headerRowOffset)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(file.FullName, FbmsInvoiceStageImports.SheetName, FbmsInvoiceStageImports.UseExistingSheetNameIfSingleSheetFound, headerRowOffset);
            return FbmsInvoiceStageImports.LoadFromXlsFile(dataTable);
        }
    }
}