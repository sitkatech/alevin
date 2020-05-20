using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.Project;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AgreementController : FirmaBaseController
    {
        //[PerformanceMeasureManageFeature]
        //public ViewResult Manage()
        //{
        //    return IndexImpl();
        //}

        [AgreementViewFeature]
        public ViewResult AgreementIndex()
        {
            return AgreementIndexImpl();
        }

        private ViewResult AgreementIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.AgreementList.GetFirmaPage();
            var viewData = new AgreementIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<AgreementIndex, AgreementIndexViewData>(viewData);
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<Agreement> AgreementGridJsonData()
        {
            var gridSpec = new AgreementGridSpec(CurrentFirmaSession);
            var agreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList().OrderBy(x => x.AgreementNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Agreement>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<Agreement> AgreementGridForOrganizationJsonData(int organizationID)
        {
            var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
            var gridSpec = new AgreementGridSpec(CurrentFirmaSession);
            var agreementsForOrganization = organization.Agreements.ToList().OrderBy(x => x.AgreementNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Agreement>(agreementsForOrganization, gridSpec);
            return gridJsonNetJObjectResult;
        }

        //[ProjectsViewFullListFeature]
        //public GridJsonNetJObjectResult<Project> IndexGridJsonData()
        //{
        //    var fundingTypes = FundingType.All.ToDictionary(x => x.FundingTypeID, x => x);
        //    var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList();
        //    var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList();
        //    var gridSpec = new IndexGridSpec(CurrentPerson, fundingTypes, geospatialAreaTypes, projectCustomAttributeTypes);
        //    var projects = HttpRequestStorage.DatabaseEntities.Projects.Include(x => x.PerformanceMeasureActuals).Include(x => x.ProjectFundingSourceBudgets).Include(x => x.ProjectFundingSourceExpenditures).Include(x => x.ProjectImages).Include(x => x.ProjectGeospatialAreas).Include(x => x.ProjectOrganizations).Include(x => x.ProjectCustomAttributes.Select(y => y.ProjectCustomAttributeValues)).Include(x => x.SecondaryProjectTaxonomyLeafs).Include(x => x.ProjectTags.Select(y => y.Tag)).Include(x => x.PrimaryContactPerson).ToList().GetActiveProjects();
        //    var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
        //    return gridJsonNetJObjectResult;
        //}

        [AgreementViewFeature]
        public ViewResult AgreementDetail(string agreementNumber)
        {
            var agreement = HttpRequestStorage.DatabaseEntities.Agreements.SingleOrDefault(a => a.AgreementNumber == agreementNumber);
            Check.EnsureNotNull(agreement, $"Agreement with Agreement Number {agreementNumber} not found!");
            var viewData = new AgreementDetailViewData(CurrentFirmaSession, agreement);
            return RazorView<AgreementDetail, AgreementDetailViewData>(viewData);
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<Project> AgreementProjectsGridJsonData(AgreementPrimaryKey agreementPrimaryKey)
        {
            var reclamationAgreement = agreementPrimaryKey.EntityObject;
            var gridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true, reclamationAgreement);
            //var projectTaxonomyBranches = taxonomyBranchPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var projectReclamationAgreements = reclamationAgreement.GetAssociatedProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectReclamationAgreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<CostAuthority> AgreementCostAuthorityGridJsonData(AgreementPrimaryKey agreementPrimaryKey)
        {
            var gridSpec = new BasicCostAuthorityGridSpec(CurrentPerson);
            var projectReclamationAgreements = agreementPrimaryKey.EntityObject.GetReclamationCostAuthorities();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<CostAuthority>(projectReclamationAgreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

    }
}