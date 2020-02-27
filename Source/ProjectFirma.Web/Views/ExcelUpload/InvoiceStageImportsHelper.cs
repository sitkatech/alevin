using System.IO;
using LtInfo.Common.ExcelWorkbookUtilities;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class InvoiceStageImportsHelper
    {
        public static InvoiceStageImports LoadFromXlsFile(Stream stream)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(stream, InvoiceStageImports.SheetName, InvoiceStageImports.UseExistingSheetNameIfSingleSheetFound);
            return InvoiceStageImports.LoadFromXlsFile(dataTable);
        }

        public static InvoiceStageImports LoadFromXlsFile(FileInfo file)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(file.FullName, InvoiceStageImports.SheetName, InvoiceStageImports.UseExistingSheetNameIfSingleSheetFound);
            return InvoiceStageImports.LoadFromXlsFile(dataTable);
        }
    }
}