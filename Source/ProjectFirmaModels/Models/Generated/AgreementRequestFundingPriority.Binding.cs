//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequestFundingPriority]
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
    public abstract partial class AgreementRequestFundingPriority : IHavePrimaryKey
    {
        public static readonly AgreementRequestFundingPriorityLow Low = AgreementRequestFundingPriorityLow.Instance;
        public static readonly AgreementRequestFundingPriorityMedium Medium = AgreementRequestFundingPriorityMedium.Instance;
        public static readonly AgreementRequestFundingPriorityHigh High = AgreementRequestFundingPriorityHigh.Instance;

        public static readonly List<AgreementRequestFundingPriority> All;
        public static readonly ReadOnlyDictionary<int, AgreementRequestFundingPriority> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static AgreementRequestFundingPriority()
        {
            All = new List<AgreementRequestFundingPriority> { Low, Medium, High };
            AllLookupDictionary = new ReadOnlyDictionary<int, AgreementRequestFundingPriority>(All.ToDictionary(x => x.AgreementRequestFundingPriorityID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected AgreementRequestFundingPriority(int agreementRequestFundingPriorityID, string agreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName)
        {
            AgreementRequestFundingPriorityID = agreementRequestFundingPriorityID;
            AgreementRequestFundingPriorityName = agreementRequestFundingPriorityName;
            AgreementRequestFundingPriorityDisplayName = agreementRequestFundingPriorityDisplayName;
        }

        [Key]
        public int AgreementRequestFundingPriorityID { get; private set; }
        public string AgreementRequestFundingPriorityName { get; private set; }
        public string AgreementRequestFundingPriorityDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return AgreementRequestFundingPriorityID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(AgreementRequestFundingPriority other)
        {
            if (other == null)
            {
                return false;
            }
            return other.AgreementRequestFundingPriorityID == AgreementRequestFundingPriorityID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as AgreementRequestFundingPriority);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return AgreementRequestFundingPriorityID;
        }

        public static bool operator ==(AgreementRequestFundingPriority left, AgreementRequestFundingPriority right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AgreementRequestFundingPriority left, AgreementRequestFundingPriority right)
        {
            return !Equals(left, right);
        }

        public AgreementRequestFundingPriorityEnum ToEnum { get { return (AgreementRequestFundingPriorityEnum)GetHashCode(); } }

        public static AgreementRequestFundingPriority ToType(int enumValue)
        {
            return ToType((AgreementRequestFundingPriorityEnum)enumValue);
        }

        public static AgreementRequestFundingPriority ToType(AgreementRequestFundingPriorityEnum enumValue)
        {
            switch (enumValue)
            {
                case AgreementRequestFundingPriorityEnum.High:
                    return High;
                case AgreementRequestFundingPriorityEnum.Low:
                    return Low;
                case AgreementRequestFundingPriorityEnum.Medium:
                    return Medium;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum AgreementRequestFundingPriorityEnum
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public partial class AgreementRequestFundingPriorityLow : AgreementRequestFundingPriority
    {
        private AgreementRequestFundingPriorityLow(int agreementRequestFundingPriorityID, string agreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName) : base(agreementRequestFundingPriorityID, agreementRequestFundingPriorityName, agreementRequestFundingPriorityDisplayName) {}
        public static readonly AgreementRequestFundingPriorityLow Instance = new AgreementRequestFundingPriorityLow(1, @"Low", @"Low");
    }

    public partial class AgreementRequestFundingPriorityMedium : AgreementRequestFundingPriority
    {
        private AgreementRequestFundingPriorityMedium(int agreementRequestFundingPriorityID, string agreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName) : base(agreementRequestFundingPriorityID, agreementRequestFundingPriorityName, agreementRequestFundingPriorityDisplayName) {}
        public static readonly AgreementRequestFundingPriorityMedium Instance = new AgreementRequestFundingPriorityMedium(2, @"Medium", @"Medium");
    }

    public partial class AgreementRequestFundingPriorityHigh : AgreementRequestFundingPriority
    {
        private AgreementRequestFundingPriorityHigh(int agreementRequestFundingPriorityID, string agreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName) : base(agreementRequestFundingPriorityID, agreementRequestFundingPriorityName, agreementRequestFundingPriorityDisplayName) {}
        public static readonly AgreementRequestFundingPriorityHigh Instance = new AgreementRequestFundingPriorityHigh(3, @"High", @"High");
    }
}