//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequestFundingPriority]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ObligationRequestFundingPriority : IHavePrimaryKey
    {
        public static readonly ObligationRequestFundingPriorityLow Low = ObligationRequestFundingPriorityLow.Instance;
        public static readonly ObligationRequestFundingPriorityMedium Medium = ObligationRequestFundingPriorityMedium.Instance;
        public static readonly ObligationRequestFundingPriorityHigh High = ObligationRequestFundingPriorityHigh.Instance;

        public static readonly List<ObligationRequestFundingPriority> All;
        public static readonly ReadOnlyDictionary<int, ObligationRequestFundingPriority> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ObligationRequestFundingPriority()
        {
            All = new List<ObligationRequestFundingPriority> { Low, Medium, High };
            AllLookupDictionary = new ReadOnlyDictionary<int, ObligationRequestFundingPriority>(All.ToDictionary(x => x.ObligationRequestFundingPriorityID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ObligationRequestFundingPriority(int obligationRequestFundingPriorityID, string obligationRequestFundingPriorityName, string obligationRequestFundingPriorityDisplayName)
        {
            ObligationRequestFundingPriorityID = obligationRequestFundingPriorityID;
            ObligationRequestFundingPriorityName = obligationRequestFundingPriorityName;
            ObligationRequestFundingPriorityDisplayName = obligationRequestFundingPriorityDisplayName;
        }

        [Key]
        public int ObligationRequestFundingPriorityID { get; private set; }
        public string ObligationRequestFundingPriorityName { get; private set; }
        public string ObligationRequestFundingPriorityDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ObligationRequestFundingPriorityID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ObligationRequestFundingPriority other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ObligationRequestFundingPriorityID == ObligationRequestFundingPriorityID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ObligationRequestFundingPriority);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ObligationRequestFundingPriorityID;
        }

        public static bool operator ==(ObligationRequestFundingPriority left, ObligationRequestFundingPriority right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObligationRequestFundingPriority left, ObligationRequestFundingPriority right)
        {
            return !Equals(left, right);
        }

        public ObligationRequestFundingPriorityEnum ToEnum { get { return (ObligationRequestFundingPriorityEnum)GetHashCode(); } }

        public static ObligationRequestFundingPriority ToType(int enumValue)
        {
            return ToType((ObligationRequestFundingPriorityEnum)enumValue);
        }

        public static ObligationRequestFundingPriority ToType(ObligationRequestFundingPriorityEnum enumValue)
        {
            switch (enumValue)
            {
                case ObligationRequestFundingPriorityEnum.High:
                    return High;
                case ObligationRequestFundingPriorityEnum.Low:
                    return Low;
                case ObligationRequestFundingPriorityEnum.Medium:
                    return Medium;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ObligationRequestFundingPriorityEnum
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public partial class ObligationRequestFundingPriorityLow : ObligationRequestFundingPriority
    {
        private ObligationRequestFundingPriorityLow(int obligationRequestFundingPriorityID, string obligationRequestFundingPriorityName, string obligationRequestFundingPriorityDisplayName) : base(obligationRequestFundingPriorityID, obligationRequestFundingPriorityName, obligationRequestFundingPriorityDisplayName) {}
        public static readonly ObligationRequestFundingPriorityLow Instance = new ObligationRequestFundingPriorityLow(1, @"Low", @"Low");
    }

    public partial class ObligationRequestFundingPriorityMedium : ObligationRequestFundingPriority
    {
        private ObligationRequestFundingPriorityMedium(int obligationRequestFundingPriorityID, string obligationRequestFundingPriorityName, string obligationRequestFundingPriorityDisplayName) : base(obligationRequestFundingPriorityID, obligationRequestFundingPriorityName, obligationRequestFundingPriorityDisplayName) {}
        public static readonly ObligationRequestFundingPriorityMedium Instance = new ObligationRequestFundingPriorityMedium(2, @"Medium", @"Medium");
    }

    public partial class ObligationRequestFundingPriorityHigh : ObligationRequestFundingPriority
    {
        private ObligationRequestFundingPriorityHigh(int obligationRequestFundingPriorityID, string obligationRequestFundingPriorityName, string obligationRequestFundingPriorityDisplayName) : base(obligationRequestFundingPriorityID, obligationRequestFundingPriorityName, obligationRequestFundingPriorityDisplayName) {}
        public static readonly ObligationRequestFundingPriorityHigh Instance = new ObligationRequestFundingPriorityHigh(3, @"High", @"High");
    }
}