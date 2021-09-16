using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Admin
{
    public class ExportSqlDataViewData : FirmaViewData
    {
        public ExportSqlDataViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Export Sql Data";
        }
    }
}