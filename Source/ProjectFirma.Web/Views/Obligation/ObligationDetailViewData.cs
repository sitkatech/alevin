/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationDetailViewData : FirmaViewData
    {
        public ObligationNumber ObligationNumber { get; }
        public string ObligationIndexUrl { get; }


        public ObligationDetailViewData(FirmaSession currentFirmaSession,
                                       ObligationNumber obligationNumber) : base(currentFirmaSession)
        {
            PageTitle = $"Obligation Number Key: {obligationNumber.ObligationNumberKey}";
            EntityName = "Obligation Detail";
            
            ObligationNumber = obligationNumber;
            ObligationIndexUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(c => c.ObligationIndex());
        }


    }
}
