/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office2010.Word;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementEditViewData : FirmaUserControlViewData
    {
        public IEnumerable<SelectListItem> ObligationNumberSelectListItems { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ContractTypeSelectListItems { get; set; }

        /// <summary>
        /// For all-new (create)
        /// </summary>
        public AgreementEditViewData() : this(null)
        {
        }

        /// <summary>
        /// For existing (edit)
        /// </summary>
        /// <param name="optionalAgreement">Optional Agreement. Use null if all-new Agreement</param>
        public AgreementEditViewData(ProjectFirmaModels.Models.Agreement optionalAgreement)
        {
            var availableUnassociatedObligationNumbers = HttpRequestStorage.DatabaseEntities.ObligationNumbers.Where(oNum => !oNum.ReclamationAgreementID.HasValue).ToList();
            if (optionalAgreement != null)
            {
                var alreadySetObligationNumber = optionalAgreement.ObligationNumbersWhereYouAreTheReclamationAgreement.SingleOrDefault();
                // Also include Obligation we are already hooked to if Agreement is provided
                if (alreadySetObligationNumber != null)
                {
                    availableUnassociatedObligationNumbers.Add(alreadySetObligationNumber);
                }
            }
            ObligationNumberSelectListItems = availableUnassociatedObligationNumbers.OrderBy(uo => uo.ObligationNumberKey).ToSelectListWithEmptyFirstRow(oNum => oNum.ObligationNumberID.ToString(CultureInfo.InvariantCulture), x => x.ObligationNumberKey);

            var activeOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            OrganizationSelectListItems = activeOrganizations.OrderBy(ao => ao.OrganizationName).ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.OrganizationName);

            var allContractTypes = HttpRequestStorage.DatabaseEntities.ContractTypes.ToList();
            ContractTypeSelectListItems = allContractTypes.OrderBy(x => x.ContractTypeDisplayName).ToSelectListWithEmptyFirstRow(x => x.ContractTypeID.ToString(), x => x.ContractTypeDisplayName);
        }


        private void SetUpAgreementEditViewData(ProjectFirmaModels.Models.Agreement optionalAgreement)
        {

        }
    }

}
