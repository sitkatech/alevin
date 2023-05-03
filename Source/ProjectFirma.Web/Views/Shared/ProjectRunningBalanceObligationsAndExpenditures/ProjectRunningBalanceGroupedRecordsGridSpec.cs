/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class ProjectRunningBalanceGroupedRecordsGridSpec : GridSpec<ProjectRunningBalanceGroupedRecord>
    {
        public ProjectRunningBalanceGroupedRecordsGridSpec()
        {

            
            Add("Fiscal Year", a => a.FiscalYear, 90, DhtmlxGridColumnFormatType.Date, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Fiscal Month Period", a => a.FiscalMonthPeriod, 90, DhtmlxGridColumnFormatType.Integer, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Fiscal Quarter", a => a.FiscalQuarter.FiscalQuarterDisplayName, 180, DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add("Commitments", a => a.Commitments, 100, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);

            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), a => a.Obligations, 100, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);
            Add("Expenditures", a => a.Expenditures, 100, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);

            Add("Undelivered Orders", a => a.UndeliveredOrders, 100, DhtmlxGridColumnFormatType.CurrencyWithCents, DhtmlxGridColumnAggregationType.Total);


            Add(FieldDefinitionEnum.BudgetObjectCode.ToType().ToGridHeaderStringPlural(), a => (a.BudgetObjectCode != null) ? a.BudgetObjectCode.GetDisplayNameAsLinkToDetail() : new HtmlString(string.Empty), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);



        }


    }
}