//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementRequestStatus]
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
    public abstract partial class ReclamationAgreementRequestStatus : IHavePrimaryKey
    {
        public static readonly ReclamationAgreementRequestStatusDraft Draft = ReclamationAgreementRequestStatusDraft.Instance;
        public static readonly ReclamationAgreementRequestStatusSubmitted Submitted = ReclamationAgreementRequestStatusSubmitted.Instance;
        public static readonly ReclamationAgreementRequestStatusProcessing Processing = ReclamationAgreementRequestStatusProcessing.Instance;
        public static readonly ReclamationAgreementRequestStatusAwarded Awarded = ReclamationAgreementRequestStatusAwarded.Instance;

        public static readonly List<ReclamationAgreementRequestStatus> All;
        public static readonly ReadOnlyDictionary<int, ReclamationAgreementRequestStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ReclamationAgreementRequestStatus()
        {
            All = new List<ReclamationAgreementRequestStatus> { Draft, Submitted, Processing, Awarded };
            AllLookupDictionary = new ReadOnlyDictionary<int, ReclamationAgreementRequestStatus>(All.ToDictionary(x => x.ReclamationAgreementRequestStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ReclamationAgreementRequestStatus(int reclamationAgreementRequestStatusID, string reclamationAgreementRequestStatusName, string agreementRequestStatusDisplayName)
        {
            ReclamationAgreementRequestStatusID = reclamationAgreementRequestStatusID;
            ReclamationAgreementRequestStatusName = reclamationAgreementRequestStatusName;
            AgreementRequestStatusDisplayName = agreementRequestStatusDisplayName;
        }

        [Key]
        public int ReclamationAgreementRequestStatusID { get; private set; }
        public string ReclamationAgreementRequestStatusName { get; private set; }
        public string AgreementRequestStatusDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementRequestStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ReclamationAgreementRequestStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ReclamationAgreementRequestStatusID == ReclamationAgreementRequestStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ReclamationAgreementRequestStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ReclamationAgreementRequestStatusID;
        }

        public static bool operator ==(ReclamationAgreementRequestStatus left, ReclamationAgreementRequestStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReclamationAgreementRequestStatus left, ReclamationAgreementRequestStatus right)
        {
            return !Equals(left, right);
        }

        public ReclamationAgreementRequestStatusEnum ToEnum { get { return (ReclamationAgreementRequestStatusEnum)GetHashCode(); } }

        public static ReclamationAgreementRequestStatus ToType(int enumValue)
        {
            return ToType((ReclamationAgreementRequestStatusEnum)enumValue);
        }

        public static ReclamationAgreementRequestStatus ToType(ReclamationAgreementRequestStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case ReclamationAgreementRequestStatusEnum.Awarded:
                    return Awarded;
                case ReclamationAgreementRequestStatusEnum.Draft:
                    return Draft;
                case ReclamationAgreementRequestStatusEnum.Processing:
                    return Processing;
                case ReclamationAgreementRequestStatusEnum.Submitted:
                    return Submitted;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ReclamationAgreementRequestStatusEnum
    {
        Draft = 1,
        Submitted = 2,
        Processing = 3,
        Awarded = 4
    }

    public partial class ReclamationAgreementRequestStatusDraft : ReclamationAgreementRequestStatus
    {
        private ReclamationAgreementRequestStatusDraft(int reclamationAgreementRequestStatusID, string reclamationAgreementRequestStatusName, string agreementRequestStatusDisplayName) : base(reclamationAgreementRequestStatusID, reclamationAgreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly ReclamationAgreementRequestStatusDraft Instance = new ReclamationAgreementRequestStatusDraft(1, @"Draft", @"Draft");
    }

    public partial class ReclamationAgreementRequestStatusSubmitted : ReclamationAgreementRequestStatus
    {
        private ReclamationAgreementRequestStatusSubmitted(int reclamationAgreementRequestStatusID, string reclamationAgreementRequestStatusName, string agreementRequestStatusDisplayName) : base(reclamationAgreementRequestStatusID, reclamationAgreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly ReclamationAgreementRequestStatusSubmitted Instance = new ReclamationAgreementRequestStatusSubmitted(2, @"Submitted", @"Submitted");
    }

    public partial class ReclamationAgreementRequestStatusProcessing : ReclamationAgreementRequestStatus
    {
        private ReclamationAgreementRequestStatusProcessing(int reclamationAgreementRequestStatusID, string reclamationAgreementRequestStatusName, string agreementRequestStatusDisplayName) : base(reclamationAgreementRequestStatusID, reclamationAgreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly ReclamationAgreementRequestStatusProcessing Instance = new ReclamationAgreementRequestStatusProcessing(3, @"Processing", @"Processing");
    }

    public partial class ReclamationAgreementRequestStatusAwarded : ReclamationAgreementRequestStatus
    {
        private ReclamationAgreementRequestStatusAwarded(int reclamationAgreementRequestStatusID, string reclamationAgreementRequestStatusName, string agreementRequestStatusDisplayName) : base(reclamationAgreementRequestStatusID, reclamationAgreementRequestStatusName, agreementRequestStatusDisplayName) {}
        public static readonly ReclamationAgreementRequestStatusAwarded Instance = new ReclamationAgreementRequestStatusAwarded(4, @"Awarded", @"Awarded");
    }
}