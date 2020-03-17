using System.IO;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class InvoiceStageImportsHelper
    {
        public static InvoiceStageImports LoadFromXlsFile(Stream stream, int headerRowOffset)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(stream, InvoiceStageImports.SheetName, InvoiceStageImports.UseExistingSheetNameIfSingleSheetFound, headerRowOffset);
            return InvoiceStageImports.LoadFromXlsFile(dataTable);
        }

        public static InvoiceStageImports LoadFromXlsFile(FileInfo file, int headerRowOffset)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(file.FullName, InvoiceStageImports.SheetName, InvoiceStageImports.UseExistingSheetNameIfSingleSheetFound, headerRowOffset);
            return InvoiceStageImports.LoadFromXlsFile(dataTable);
        }
    }
}