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
        //public readonly IEnumerable<SelectListItem> OrganizationTypes;
        //public readonly IEnumerable<SelectListItem> People;
        //public readonly bool IsInKeystone;
        //public readonly string RequestOrganizationChangeUrl;
        //public readonly bool IsSitkaAdmin;
        //public readonly bool UserHasAdminPermissions;
        //public readonly Guid? OrganizationGuid;
        //public readonly string SyncWithKeystoneUrl;

        public AgreementEditViewData(/*IEnumerable<SelectListItem> organizationTypes, IEnumerable<SelectListItem> people, bool isInKeystone, string requestOrganizationChangeUrl, bool isSitkaAdmin, bool userHasAdminPermissions, Guid? organizationGuid*/)
        {
            var allContractTypes = HttpRequestStorage.DatabaseEntities.ContractTypes.ToList();
            ContractTypeSelectListItems = allContractTypes.OrderBy(x => x.ContractTypeDisplayName).ToSelectListWithEmptyFirstRow(x => x.ContractTypeID.ToString(), x => x.ContractTypeDisplayName);

            var activeOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            OrganizationSelectListItems = activeOrganizations.ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.OrganizationName);

            /*
            OrganizationTypes = organizationTypes;
            People = people;
            IsInKeystone = isInKeystone;
            RequestOrganizationChangeUrl = requestOrganizationChangeUrl;
            IsSitkaAdmin = isSitkaAdmin;
            UserHasAdminPermissions = userHasAdminPermissions;
            OrganizationGuid = organizationGuid;
            SyncWithKeystoneUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.SyncWithKeystone(UrlTemplate.Parameter1String));
            */
        }
    }

}
