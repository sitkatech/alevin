//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vProjectEffectiveTaxonomyLeaf]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class vProjectEffectiveTaxonomyLeaf
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vProjectEffectiveTaxonomyLeaf()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vProjectEffectiveTaxonomyLeaf(int projectID, int primaryKey, int? tlTaxLeafID, int? caTaxLeafID, int? effectiveTaxonomyLeafID) : this()
        {
            this.ProjectID = projectID;
            this.PrimaryKey = primaryKey;
            this.tlTaxLeafID = tlTaxLeafID;
            this.caTaxLeafID = caTaxLeafID;
            this.EffectiveTaxonomyLeafID = effectiveTaxonomyLeafID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vProjectEffectiveTaxonomyLeaf(vProjectEffectiveTaxonomyLeaf vProjectEffectiveTaxonomyLeaf) : this()
        {
            this.ProjectID = vProjectEffectiveTaxonomyLeaf.ProjectID;
            this.PrimaryKey = vProjectEffectiveTaxonomyLeaf.PrimaryKey;
            this.tlTaxLeafID = vProjectEffectiveTaxonomyLeaf.tlTaxLeafID;
            this.caTaxLeafID = vProjectEffectiveTaxonomyLeaf.caTaxLeafID;
            this.EffectiveTaxonomyLeafID = vProjectEffectiveTaxonomyLeaf.EffectiveTaxonomyLeafID;
            CallAfterConstructor(vProjectEffectiveTaxonomyLeaf);
        }

        partial void CallAfterConstructor(vProjectEffectiveTaxonomyLeaf vProjectEffectiveTaxonomyLeaf);

        public int ProjectID { get; set; }
        public int PrimaryKey { get; set; }
        public int? tlTaxLeafID { get; set; }
        public int? caTaxLeafID { get; set; }
        public int? EffectiveTaxonomyLeafID { get; set; }
    }
}