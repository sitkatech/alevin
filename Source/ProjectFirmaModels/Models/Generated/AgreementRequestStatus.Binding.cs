//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequestStatus]
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
    public abstract partial class AgreementRequestStatus : IHavePrimaryKey
    {
        public static readonly AgreementRequestStatusDraft Draft = AgreementRequestStatusDraft.Instance;
        public static readonly AgreementRequestStatusSubmitted Submitted = AgreementRequestStatusSubmitted.Instance;
        public static readonly AgreementRequestStatusProcessing Processing = AgreementRequestStatusProcessing.Instance;
        public static readonly AgreementRequestStatusAwarded Awarded = AgreementRequestStatusAwarded.Instance;

        public static readonly List<AgreementRequestStatus> All;
        public static readonly ReadOnlyDictionary<int, AgreementRequestStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static AgreementRequestStatus()
        {
            All = new List<AgreementRequestStatus> { Draft, Submitted, Processing, Awarded };
            AllLookupDictionary = new ReadOnlyDictionary<int, AgreementRequestStatus>(All.ToDictionary(x => x.AgreementRequestStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected AgreementRequestStatus(int agreementRequestStatusID, string agreementRequestStatusName, string agreementRequestStatusDisplayName)
        {
            AgreementRequestStatusID = agreementRequestStatusID;
            AgreementRequestStatusName = agreementRequestStatusName;
            AgreementRequestStatusDisplayName = agreementRequestStatusDisplayName;
        }

        [Key]
        public int AgreementRequestStatusID { get; private set; }
        public string AgreementRequestStatusName { get; private set; }
        public string AgreementRequestStatusDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return AgreementRequestStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(AgreementRequestStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.AgreementRequestStatusID == AgreementRequestStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as AgreementRequestStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return AgreementRequestStatusID;
        }

        public static bool operator ==(AgreementRequestStatus left, AgreementRequestStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AgreementRequestStatus left, AgreementRequestStatus right)
        {
            return !Equals(left, right);
        }

        public AgreementRequestStatusEnum ToEnum { get { return (AgreementRequestStatusEnum)GetHashCode(); } }

        public static AgreementRequestStatus ToType(int enumValue)
        {
            return ToType((AgreementRequestStatusEnum)enumValue);
        }

        public static AgreementRequestStatus ToType(AgreementRequestStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case AgreementRequestStatusEnum.Awarded:
                    return Awarded;
                case AgreementRequestStatusEnum.Draft:
                    return Draft;
                case AgreementRequestStatusEnum.Processing:
                    return Processing;
                case AgreementRequestStatusEnum.Submitted:
                    return Submitted;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum AgreementRequestStatusEnum
    {
        Draft = 1,
        Submitted = 2,
        Processing = 3,
        Awarded = 4
    }

    public partial class AgreementRequestStatusDraft : AgreementRequestStatus
    {
        private AgreementRequestStatusDraft(int agreementRequestStatusID, string agreementRequestStatusName, string agreementRequestStatusDisplayName) : base(agreementRequestStatusID, agreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly AgreementRequestStatusDraft Instance = new AgreementRequestStatusDraft(1, @"Draft", @"Draft");
    }

    public partial class AgreementRequestStatusSubmitted : AgreementRequestStatus
    {
        private AgreementRequestStatusSubmitted(int agreementRequestStatusID, string agreementRequestStatusName, string agreementRequestStatusDisplayName) : base(agreementRequestStatusID, agreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly AgreementRequestStatusSubmitted Instance = new AgreementRequestStatusSubmitted(2, @"Submitted", @"Submitted");
    }

    public partial class AgreementRequestStatusProcessing : AgreementRequestStatus
    {
        private AgreementRequestStatusProcessing(int agreementRequestStatusID, string agreementRequestStatusName, string agreementRequestStatusDisplayName) : base(agreementRequestStatusID, agreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly AgreementRequestStatusProcessing Instance = new AgreementRequestStatusProcessing(3, @"Processing", @"Processing");
    }

    public partial class AgreementRequestStatusAwarded : AgreementRequestStatus
    {
        private AgreementRequestStatusAwarded(int agreementRequestStatusID, string agreementRequestStatusName, string agreementRequestStatusDisplayName) : base(agreementRequestStatusID, agreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly AgreementRequestStatusAwarded Instance = new AgreementRequestStatusAwarded(4, @"Awarded", @"Awarded");
    }
}