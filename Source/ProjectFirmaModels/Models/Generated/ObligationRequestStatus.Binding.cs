//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequestStatus]
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
    public abstract partial class ObligationRequestStatus : IHavePrimaryKey
    {
        public static readonly ObligationRequestStatusDraft Draft = ObligationRequestStatusDraft.Instance;
        public static readonly ObligationRequestStatusSubmitted Submitted = ObligationRequestStatusSubmitted.Instance;
        public static readonly ObligationRequestStatusProcessing Processing = ObligationRequestStatusProcessing.Instance;
        public static readonly ObligationRequestStatusAwarded Awarded = ObligationRequestStatusAwarded.Instance;

        public static readonly List<ObligationRequestStatus> All;
        public static readonly ReadOnlyDictionary<int, ObligationRequestStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ObligationRequestStatus()
        {
            All = new List<ObligationRequestStatus> { Draft, Submitted, Processing, Awarded };
            AllLookupDictionary = new ReadOnlyDictionary<int, ObligationRequestStatus>(All.ToDictionary(x => x.ObligationRequestStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ObligationRequestStatus(int obligationRequestStatusID, string obligationRequestStatusName, string obligationRequestStatusDisplayName)
        {
            ObligationRequestStatusID = obligationRequestStatusID;
            ObligationRequestStatusName = obligationRequestStatusName;
            ObligationRequestStatusDisplayName = obligationRequestStatusDisplayName;
        }

        [Key]
        public int ObligationRequestStatusID { get; private set; }
        public string ObligationRequestStatusName { get; private set; }
        public string ObligationRequestStatusDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ObligationRequestStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ObligationRequestStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ObligationRequestStatusID == ObligationRequestStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ObligationRequestStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ObligationRequestStatusID;
        }

        public static bool operator ==(ObligationRequestStatus left, ObligationRequestStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObligationRequestStatus left, ObligationRequestStatus right)
        {
            return !Equals(left, right);
        }

        public ObligationRequestStatusEnum ToEnum { get { return (ObligationRequestStatusEnum)GetHashCode(); } }

        public static ObligationRequestStatus ToType(int enumValue)
        {
            return ToType((ObligationRequestStatusEnum)enumValue);
        }

        public static ObligationRequestStatus ToType(ObligationRequestStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case ObligationRequestStatusEnum.Awarded:
                    return Awarded;
                case ObligationRequestStatusEnum.Draft:
                    return Draft;
                case ObligationRequestStatusEnum.Processing:
                    return Processing;
                case ObligationRequestStatusEnum.Submitted:
                    return Submitted;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ObligationRequestStatusEnum
    {
        Draft = 1,
        Submitted = 2,
        Processing = 3,
        Awarded = 4
    }

    public partial class ObligationRequestStatusDraft : ObligationRequestStatus
    {
        private ObligationRequestStatusDraft(int obligationRequestStatusID, string obligationRequestStatusName, string obligationRequestStatusDisplayName) : base(obligationRequestStatusID, obligationRequestStatusName, obligationRequestStatusDisplayName) {}
        public static readonly ObligationRequestStatusDraft Instance = new ObligationRequestStatusDraft(1, @"Draft", @"Draft");
    }

    public partial class ObligationRequestStatusSubmitted : ObligationRequestStatus
    {
        private ObligationRequestStatusSubmitted(int obligationRequestStatusID, string obligationRequestStatusName, string obligationRequestStatusDisplayName) : base(obligationRequestStatusID, obligationRequestStatusName, obligationRequestStatusDisplayName) {}
        public static readonly ObligationRequestStatusSubmitted Instance = new ObligationRequestStatusSubmitted(2, @"Submitted", @"Submitted");
    }

    public partial class ObligationRequestStatusProcessing : ObligationRequestStatus
    {
        private ObligationRequestStatusProcessing(int obligationRequestStatusID, string obligationRequestStatusName, string obligationRequestStatusDisplayName) : base(obligationRequestStatusID, obligationRequestStatusName, obligationRequestStatusDisplayName) {}
        public static readonly ObligationRequestStatusProcessing Instance = new ObligationRequestStatusProcessing(3, @"Processing", @"Processing");
    }

    public partial class ObligationRequestStatusAwarded : ObligationRequestStatus
    {
        private ObligationRequestStatusAwarded(int obligationRequestStatusID, string obligationRequestStatusName, string obligationRequestStatusDisplayName) : base(obligationRequestStatusID, obligationRequestStatusName, obligationRequestStatusDisplayName) {}
        public static readonly ObligationRequestStatusAwarded Instance = new ObligationRequestStatusAwarded(4, @"Awarded", @"Awarded");
    }
}