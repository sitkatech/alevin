//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementRequestFundingPriority]
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
    public abstract partial class ReclamationAgreementRequestFundingPriority : IHavePrimaryKey
    {
        public static readonly ReclamationAgreementRequestFundingPriorityLow Low = ReclamationAgreementRequestFundingPriorityLow.Instance;
        public static readonly ReclamationAgreementRequestFundingPriorityMedium Medium = ReclamationAgreementRequestFundingPriorityMedium.Instance;
        public static readonly ReclamationAgreementRequestFundingPriorityHigh High = ReclamationAgreementRequestFundingPriorityHigh.Instance;

        public static readonly List<ReclamationAgreementRequestFundingPriority> All;
        public static readonly ReadOnlyDictionary<int, ReclamationAgreementRequestFundingPriority> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ReclamationAgreementRequestFundingPriority()
        {
            All = new List<ReclamationAgreementRequestFundingPriority> { Low, Medium, High };
            AllLookupDictionary = new ReadOnlyDictionary<int, ReclamationAgreementRequestFundingPriority>(All.ToDictionary(x => x.ReclamationAgreementRequestFundingPriorityID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ReclamationAgreementRequestFundingPriority(int reclamationAgreementRequestFundingPriorityID, string reclamationAgreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName)
        {
            ReclamationAgreementRequestFundingPriorityID = reclamationAgreementRequestFundingPriorityID;
            ReclamationAgreementRequestFundingPriorityName = reclamationAgreementRequestFundingPriorityName;
            AgreementRequestFundingPriorityDisplayName = agreementRequestFundingPriorityDisplayName;
        }

        [Key]
        public int ReclamationAgreementRequestFundingPriorityID { get; private set; }
        public string ReclamationAgreementRequestFundingPriorityName { get; private set; }
        public string AgreementRequestFundingPriorityDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementRequestFundingPriorityID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ReclamationAgreementRequestFundingPriority other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ReclamationAgreementRequestFundingPriorityID == ReclamationAgreementRequestFundingPriorityID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ReclamationAgreementRequestFundingPriority);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ReclamationAgreementRequestFundingPriorityID;
        }

        public static bool operator ==(ReclamationAgreementRequestFundingPriority left, ReclamationAgreementRequestFundingPriority right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReclamationAgreementRequestFundingPriority left, ReclamationAgreementRequestFundingPriority right)
        {
            return !Equals(left, right);
        }

        public ReclamationAgreementRequestFundingPriorityEnum ToEnum { get { return (ReclamationAgreementRequestFundingPriorityEnum)GetHashCode(); } }

        public static ReclamationAgreementRequestFundingPriority ToType(int enumValue)
        {
            return ToType((ReclamationAgreementRequestFundingPriorityEnum)enumValue);
        }

        public static ReclamationAgreementRequestFundingPriority ToType(ReclamationAgreementRequestFundingPriorityEnum enumValue)
        {
            switch (enumValue)
            {
                case ReclamationAgreementRequestFundingPriorityEnum.High:
                    return High;
                case ReclamationAgreementRequestFundingPriorityEnum.Low:
                    return Low;
                case ReclamationAgreementRequestFundingPriorityEnum.Medium:
                    return Medium;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ReclamationAgreementRequestFundingPriorityEnum
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public partial class ReclamationAgreementRequestFundingPriorityLow : ReclamationAgreementRequestFundingPriority
    {
        private ReclamationAgreementRequestFundingPriorityLow(int reclamationAgreementRequestFundingPriorityID, string reclamationAgreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName) : base(reclamationAgreementRequestFundingPriorityID, reclamationAgreementRequestFundingPriorityName, agreementRequestFundingPriorityDisplayName) {}
        public static readonly ReclamationAgreementRequestFundingPriorityLow Instance = new ReclamationAgreementRequestFundingPriorityLow(1, @"Low", @"Low");
    }

    public partial class ReclamationAgreementRequestFundingPriorityMedium : ReclamationAgreementRequestFundingPriority
    {
        private ReclamationAgreementRequestFundingPriorityMedium(int reclamationAgreementRequestFundingPriorityID, string reclamationAgreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName) : base(reclamationAgreementRequestFundingPriorityID, reclamationAgreementRequestFundingPriorityName, agreementRequestFundingPriorityDisplayName) {}
        public static readonly ReclamationAgreementRequestFundingPriorityMedium Instance = new ReclamationAgreementRequestFundingPriorityMedium(2, @"Medium", @"Medium");
    }

    public partial class ReclamationAgreementRequestFundingPriorityHigh : ReclamationAgreementRequestFundingPriority
    {
        private ReclamationAgreementRequestFundingPriorityHigh(int reclamationAgreementRequestFundingPriorityID, string reclamationAgreementRequestFundingPriorityName, string agreementRequestFundingPriorityDisplayName) : base(reclamationAgreementRequestFundingPriorityID, reclamationAgreementRequestFundingPriorityName, agreementRequestFundingPriorityDisplayName) {}
        public static readonly ReclamationAgreementRequestFundingPriorityHigh Instance = new ReclamationAgreementRequestFundingPriorityHigh(3, @"High", @"High");
    }
}