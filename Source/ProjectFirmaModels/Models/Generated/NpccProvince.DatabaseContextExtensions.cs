//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NpccProvince]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static NpccProvince GetNpccProvince(this IQueryable<NpccProvince> npccProvinces, int npccProvinceID)
        {
            var npccProvince = npccProvinces.SingleOrDefault(x => x.NpccProvinceID == npccProvinceID);
            Check.RequireNotNullThrowNotFound(npccProvince, "NpccProvince", npccProvinceID);
            return npccProvince;
        }

    }
}