//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NpccSubbasinProvince]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static NpccSubbasinProvince GetNpccSubbasinProvince(this IQueryable<NpccSubbasinProvince> npccSubbasinProvinces, int npccSubbasinProvinceID)
        {
            var npccSubbasinProvince = npccSubbasinProvinces.SingleOrDefault(x => x.NpccSubbasinProvinceID == npccSubbasinProvinceID);
            Check.RequireNotNullThrowNotFound(npccSubbasinProvince, "NpccSubbasinProvince", npccSubbasinProvinceID);
            return npccSubbasinProvince;
        }

    }
}