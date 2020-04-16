﻿using System;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.BudgetObjectCode;
using ProjectFirmaModels.Models;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Obligation;

namespace ProjectFirma.Web.Controllers
{
    public class BudgetObjectCodeController : FirmaBaseController
    {

        [BudgetObjectCodeViewFeature]
        public ViewResult BudgetObjectCodeIndex()
        {
            return BudgetObjectCodeIndexImpl();
        }

        private ViewResult BudgetObjectCodeIndexImpl()
        {
            var viewData = new BudgetObjectCodeIndexViewData(CurrentFirmaSession);
            return RazorView<BudgetObjectCodeIndex, BudgetObjectCodeIndexViewData>(viewData);
        }

        [BudgetObjectCodeViewFeature]
        public GridJsonNetJObjectResult<BudgetObjectCode> BudgetObjectCodeGridJsonData()
        {
            var gridSpec = new BudgetObjectCodeGridSpec(CurrentFirmaSession);
            var budgetObjectCodes = HttpRequestStorage.DatabaseEntities.BudgetObjectCodes.ToList().OrderBy(x => x.GetDisplayName()).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<BudgetObjectCode>(budgetObjectCodes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [BudgetObjectCodeViewFeature]
        public ViewResult BudgetObjectCodeDetail(BudgetObjectCodePrimaryKey budgetObjectCodePrimaryKey)
        {
            var budgetObjectCode = budgetObjectCodePrimaryKey.EntityObject;
            var viewData = new BudgetObjectCodeDetailViewData(CurrentFirmaSession, budgetObjectCode);
            return RazorView<BudgetObjectCodeDetail, BudgetObjectCodeDetailViewData>(viewData);
        }

        [BudgetObjectCodeViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ObligationItemBudgetGridOnBudgetObjectCodeDetailJsonData(BudgetObjectCodePrimaryKey budgetObjectCodePrimaryKey)
        {
            var gridSpec = new ObligationItemBudgetGridSpec(CurrentFirmaSession);
            var budgetObjectCode = budgetObjectCodePrimaryKey.EntityObject;
            var obligationItemBudgets = budgetObjectCode.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [BudgetObjectCodeViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ObligationItemInvoiceGridOnBudgetObjectCodeDetailJsonData(BudgetObjectCodePrimaryKey budgetObjectCodePrimaryKey)
        {
            var gridSpec = new ObligationItemBudgetGridSpec(CurrentFirmaSession);
            var budgetObjectCode = budgetObjectCodePrimaryKey.EntityObject;
            var obligationItemBudgets = budgetObjectCode.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }

        #region BudgetObjectCodeGroupingsTreeGrid 

        [BudgetObjectCodeViewFeature]
        public ActionResult BudgetObjectCodeTreeGridJsonData()
        {
            string budgetObjectCodeTreeGridJsonString =  BudgetObjectCodeJsonBuilder.GetBudgetObjectGroupHierarchyAsJson();
            return Content(budgetObjectCodeTreeGridJsonString, "application/json");
        }

        #endregion BudgetObjectCodeGroupingsTreeGrid
    }
}