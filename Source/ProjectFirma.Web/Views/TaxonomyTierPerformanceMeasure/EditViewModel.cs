﻿/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierPerformanceMeasure
{
    public class EditViewModel : FormViewModel
    {
        public List<TaxonomyTierPerformanceMeasureSimple> TaxonomyTierPerformanceMeasures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(List<TaxonomyTierPerformanceMeasureSimple> taxonomyTierPerformanceMeasureSimples)
        {
            TaxonomyTierPerformanceMeasures = taxonomyTierPerformanceMeasureSimples;
        }

        public void UpdateModel(List<TaxonomyLeafPerformanceMeasure> currentTaxonomyLeafPerformanceMeasures, IList<TaxonomyLeafPerformanceMeasure> allTaxonomyLeafPerformanceMeasures)
        {
            var taxonomyLeafPerformanceMeasuresUpdated = new List<TaxonomyLeafPerformanceMeasure>();
            if (TaxonomyTierPerformanceMeasures != null)
            {
                // Completely rebuild the list
                var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
                if (associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Trunk)
                {
                    var taxonomyTrunkIDsSelected = TaxonomyTierPerformanceMeasures.Select(x => x.TaxonomyTierID).ToList();
                    var taxonomyBranchesForTrunk = HttpRequestStorage.DatabaseEntities.TaxonomyBranches
                        .Where(x => taxonomyTrunkIDsSelected.Contains(x.TaxonomyTrunkID))
                        .ToLookup(x => x.TaxonomyTrunkID);
                    taxonomyLeafPerformanceMeasuresUpdated = TaxonomyTierPerformanceMeasures.SelectMany(tt =>
                        taxonomyBranchesForTrunk[tt.TaxonomyTierID].SelectMany(tb => tb.TaxonomyLeafs.Select(x =>
                            new TaxonomyLeafPerformanceMeasure(x.TaxonomyLeafID, tt.PerformanceMeasureID)))).ToList();

                }
                else if (associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Branch)
                {
                    var taxonomyBranchIDsSelected =
                        TaxonomyTierPerformanceMeasures.Select(x => x.TaxonomyTierID).ToList();
                    var taxonomyLeafsForBranch = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs
                        .Where(x => taxonomyBranchIDsSelected.Contains(x.TaxonomyBranchID))
                        .ToLookup(x => x.TaxonomyBranchID);
                    taxonomyLeafPerformanceMeasuresUpdated = TaxonomyTierPerformanceMeasures.SelectMany(tb =>
                        taxonomyLeafsForBranch[tb.TaxonomyTierID].Select(x =>
                            new TaxonomyLeafPerformanceMeasure(x.TaxonomyLeafID, tb.PerformanceMeasureID))).ToList();
                }
                else
                {
                    taxonomyLeafPerformanceMeasuresUpdated = TaxonomyTierPerformanceMeasures.Select(x => new TaxonomyLeafPerformanceMeasure(x.TaxonomyTierID, x.PerformanceMeasureID)).ToList();
                }
            }
            currentTaxonomyLeafPerformanceMeasures.Merge(taxonomyLeafPerformanceMeasuresUpdated,
                allTaxonomyLeafPerformanceMeasures,
                (x, y) => x.TaxonomyLeafID == y.TaxonomyLeafID && x.PerformanceMeasureID == y.PerformanceMeasureID, HttpRequestStorage.DatabaseEntities);
        }
    }
}
