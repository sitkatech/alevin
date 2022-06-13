/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class ObligationRequestGridSpec : GridSpec<ProjectFirmaModels.Models.ObligationRequest>
    {
        public ObligationRequestGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => ModalDialogFormHelper.MakeDeleteIconLink(x.GetDeleteUrl(), "Delete Obligation Request", true), 30, DhtmlxGridColumnFilterType.None);

            // More Human readable version of ObligationRequestID ("OBREQ-XXX")
            // ObligationRequestNumber
            Add(FieldDefinitionEnum.ObligationRequestNumber.ToType().ToGridHeaderString()
                , a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.GetObligationRequestNumber())
                , 100
                , DhtmlxGridColumnFilterType.Html);

            // Status
            Add(FieldDefinitionEnum.Status.ToType().ToGridHeaderString(), a => a.ObligationRequestStatus.ObligationRequestStatusDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);

            //IsMod
            Add(FieldDefinitionEnum.IsModification.ToType().ToGridHeaderString("Is Modification?"), a => a.IsModification.ToYesNo(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);

            // ContractType
            Add(FieldDefinitionEnum.ContractType.ToType().ToGridHeaderString(), a => a.ContractType.ContractTypeDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);

            // AgreementNumber
            Add(FieldDefinitionEnum.AgreementNumber.ToType().ToGridHeaderString(), a => a.AgreementID.HasValue ? UrlTemplate.MakeHrefString(a.Agreement.GetDetailUrl(), a.Agreement.GetDisplayName()) : null, 100, DhtmlxGridColumnFilterType.Html);

            // Description of Need
            Add(FieldDefinitionEnum.DescriptionOfNeed.ToType().ToGridHeaderString(), a => a.DescriptionOfNeed, 100, DhtmlxGridColumnFilterType.Text);

            // Funding Priority
            Add(FieldDefinitionEnum.FundingPriority.ToType().ToGridHeaderString(), a => a.ReclamationObligationRequestFundingPriority?.ObligationRequestFundingPriorityDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);

            // Total Projected Obligation
            Add(FieldDefinitionEnum.TotalProjectedObligation.ToType().ToGridHeaderString(), a => a.TotalProjectedObligation, 100, DhtmlxGridColumnFormatType.Currency);

            // Target Award Date
            Add(FieldDefinitionEnum.TargetAwardDate.ToType().ToGridHeaderString(), a => a.TargetAwardDate, 120);

            // Palt
            Add(FieldDefinitionEnum.PALT.ToType().ToGridHeaderString(), a => a.PALT?.ToString(), 120, DhtmlxGridColumnFilterType.Numeric);

            // Target Submittal Date
            Add(FieldDefinitionEnum.TargetAwardDate.ToType().ToGridHeaderString(), a => a.TargetSubmittalDate, 120);
          
            // Mod number
            Add(FieldDefinitionEnum.ModNumber.ToType().ToGridHeaderString(), a => a.ModNumber?.ToString(), 60, DhtmlxGridColumnFilterType.Numeric);
        }
    }
}



