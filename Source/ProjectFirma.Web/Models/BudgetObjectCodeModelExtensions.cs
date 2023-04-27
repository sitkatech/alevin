﻿using System.Web;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class BudgetObjectCodeModelExtensions
    {
        public static readonly UrlTemplate<int> FundDetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(fc => fc.BudgetObjectCodeDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this BudgetObjectCode budgetObjectCode)
        {
            return FundDetailUrlTemplate.ParameterReplace(budgetObjectCode.PrimaryKey);
        }

        public static HtmlString GetDisplayNameAsLinkToDetail(this BudgetObjectCode budgetObjectCode)
        {

            return UrlTemplate.MakeHrefString(budgetObjectCode.GetDetailUrl(), budgetObjectCode.GetDisplayName());
        }


    }
}