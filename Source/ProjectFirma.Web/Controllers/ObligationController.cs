﻿using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ObligationController : FirmaBaseController
    {

        [ObligationViewFeature]
        public ViewResult ObligationIndex()
        {
            return ObligationIndexImpl();
        }

        private ViewResult ObligationIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.ObligationList.GetFirmaPage();
            var viewData = new ObligationIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<ObligationIndex, ObligationIndexViewData>(viewData);
        }

        [ObligationViewFeature]
        public GridJsonNetJObjectResult<ObligationNumber> ObligationNumberGridJsonData()
        {
            var gridSpec = new ObligationGridSpec(CurrentFirmaSession);
            var obligations = HttpRequestStorage.DatabaseEntities.ObligationNumbers.ToList().OrderBy(x => x.ObligationNumberKey).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ObligationNumber>(obligations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ObligationViewFeature]
        //public ViewResult Detail(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        // Can we / should we use the ObligationNumber as the primary key string?
        public ViewResult ObligationDetail(ObligationNumberPrimaryKey ObligationPrimaryKey)
        {
            var Obligation = ObligationPrimaryKey.EntityObject;
            var viewData = new ObligationDetailViewData(CurrentFirmaSession, Obligation);
            return RazorView<ObligationDetail, ObligationDetailViewData>(viewData);
        }

        //[ObligationViewFeature]
        //public GridJsonNetJObjectResult<Project> ObligationProjectsGridJsonData(ObligationNumberPrimaryKey reclamationObligationPrimaryKey)
        //{
        //    var reclamationObligation = reclamationObligationPrimaryKey.EntityObject;
        //    var gridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true, reclamationObligation);
        //    //var projectTaxonomyBranches = taxonomyBranchPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
        //    var projectReclamationObligations = reclamationObligation.GetAssociatedProjects();
        //    var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectReclamationObligations, gridSpec);
        //    return gridJsonNetJObjectResult;
        //}

        //[ObligationViewFeature]
        //public GridJsonNetJObjectResult<ReclamationCostAuthority> ObligationCostAuthorityGridJsonData(ObligationNumberPrimaryKey reclamationObligationPrimaryKey)
        //{
        //    var gridSpec = new BasicCostAuthorityGridSpec(CurrentPerson);
        //    var projectReclamationObligations = reclamationObligationPrimaryKey.EntityObject.GetReclamationCostAuthorities();
        //    var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ReclamationCostAuthority>(projectReclamationObligations, gridSpec);
        //    return gridJsonNetJObjectResult;
        //}




    }
}