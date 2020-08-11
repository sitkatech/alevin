﻿/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingOrganizationType.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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

using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class BiOpAnnualReportGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        public BiOpAnnualReportGridSpec()
        {


            Add(FieldDefinitionEnum.Project.ToType().FieldDefinitionDisplayName, a => a.GetDisplayNameAsUrl(), 250);
            //Add(FieldDefinitionEnum.ClassificationDescription.ToType().ToGridHeaderString("Description"), a => a.ClassificationDescription, 250);
            //Add(FieldDefinitionEnum.ClassificationDescription.ToType().ToGridHeaderString("Goal Statement"), a => a.GoalStatement, 250);
            //Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", a => a.ProjectClassifications.Count, 90);
            //Add("Sort Order", a => a.ClassificationSortOrder, 90, DhtmlxGridColumnFormatType.None);  // Most humans ordinarily expect lists to be 1-indexed instead of zero-indexed)
        }
    }
}
