//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpProcessingTableType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ImpProcessingTableType : IHavePrimaryKey
    {
        public static readonly ImpProcessingTableTypeFBMS FBMS = ImpProcessingTableTypeFBMS.Instance;
        public static readonly ImpProcessingTableTypePNBudget PNBudget = ImpProcessingTableTypePNBudget.Instance;

        public static readonly List<ImpProcessingTableType> All;
        public static readonly ReadOnlyDictionary<int, ImpProcessingTableType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ImpProcessingTableType()
        {
            All = new List<ImpProcessingTableType> { FBMS, PNBudget };
            AllLookupDictionary = new ReadOnlyDictionary<int, ImpProcessingTableType>(All.ToDictionary(x => x.ImpProcessingTableTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ImpProcessingTableType(int impProcessingTableTypeID, string impProcessingTableTypeName)
        {
            ImpProcessingTableTypeID = impProcessingTableTypeID;
            ImpProcessingTableTypeName = impProcessingTableTypeName;
        }

        [Key]
        public int ImpProcessingTableTypeID { get; private set; }
        public string ImpProcessingTableTypeName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ImpProcessingTableTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ImpProcessingTableType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ImpProcessingTableTypeID == ImpProcessingTableTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ImpProcessingTableType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ImpProcessingTableTypeID;
        }

        public static bool operator ==(ImpProcessingTableType left, ImpProcessingTableType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ImpProcessingTableType left, ImpProcessingTableType right)
        {
            return !Equals(left, right);
        }

        public ImpProcessingTableTypeEnum ToEnum { get { return (ImpProcessingTableTypeEnum)GetHashCode(); } }

        public static ImpProcessingTableType ToType(int enumValue)
        {
            return ToType((ImpProcessingTableTypeEnum)enumValue);
        }

        public static ImpProcessingTableType ToType(ImpProcessingTableTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ImpProcessingTableTypeEnum.FBMS:
                    return FBMS;
                case ImpProcessingTableTypeEnum.PNBudget:
                    return PNBudget;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ImpProcessingTableTypeEnum
    {
        FBMS = 1,
        PNBudget = 2
    }

    public partial class ImpProcessingTableTypeFBMS : ImpProcessingTableType
    {
        private ImpProcessingTableTypeFBMS(int impProcessingTableTypeID, string impProcessingTableTypeName) : base(impProcessingTableTypeID, impProcessingTableTypeName) {}
        public static readonly ImpProcessingTableTypeFBMS Instance = new ImpProcessingTableTypeFBMS(1, @"FBMS");
    }

    public partial class ImpProcessingTableTypePNBudget : ImpProcessingTableType
    {
        private ImpProcessingTableTypePNBudget(int impProcessingTableTypeID, string impProcessingTableTypeName) : base(impProcessingTableTypeID, impProcessingTableTypeName) {}
        public static readonly ImpProcessingTableTypePNBudget Instance = new ImpProcessingTableTypePNBudget(2, @"PNBudget");
    }
}