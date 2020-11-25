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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementEditViewData : FirmaUserControlViewData
    {
        public IEnumerable<SelectListItem> ContractTypeSelectListItems { get; }
        public IEnumerable<SelectListItem> OrganizationSelectListItems { get; }
        public IEnumerable<SelectListItem> ObligationNumberSelectListItems { get; }

        public AgreementEditViewData()
        {
            var allContractTypes = HttpRequestStorage.DatabaseEntities.ContractTypes.ToList();
            ContractTypeSelectListItems = allContractTypes.OrderBy(x => x.ContractTypeDisplayName).ToSelectListWithEmptyFirstRow(x => x.ContractTypeID.ToString(), x => x.ContractTypeDisplayName);

            var activeOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            OrganizationSelectListItems = activeOrganizations.OrderBy(ao => ao.OrganizationName).ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.OrganizationName);

            var availableUnassociatedObligationNumbers = HttpRequestStorage.DatabaseEntities.ObligationNumbers.Where(oNum => !oNum.ReclamationAgreementID.HasValue).ToList();
            ObligationNumberSelectListItems = availableUnassociatedObligationNumbers.OrderBy(uo => uo.ObligationNumberKey).ToSelectListWithEmptyFirstRow(oNum => oNum.ObligationNumberID.ToString(CultureInfo.InvariantCulture), x => x.ObligationNumberKey);
        }
    }

}
