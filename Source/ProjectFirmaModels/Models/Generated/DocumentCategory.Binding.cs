//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentCategory]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class DocumentCategory : IHavePrimaryKey
    {
        public static readonly DocumentCategoryMeetingNotes MeetingNotes = DocumentCategoryMeetingNotes.Instance;
        public static readonly DocumentCategoryMeetingAgendas MeetingAgendas = DocumentCategoryMeetingAgendas.Instance;
        public static readonly DocumentCategoryRequestForProposals RequestForProposals = DocumentCategoryRequestForProposals.Instance;
        public static readonly DocumentCategoryManualsAndGuidance ManualsAndGuidance = DocumentCategoryManualsAndGuidance.Instance;
        public static readonly DocumentCategoryPresentations Presentations = DocumentCategoryPresentations.Instance;
        public static readonly DocumentCategoryProgramInformation ProgramInformation = DocumentCategoryProgramInformation.Instance;
        public static readonly DocumentCategoryProgramManagement ProgramManagement = DocumentCategoryProgramManagement.Instance;
        public static readonly DocumentCategoryProgressReport ProgressReport = DocumentCategoryProgressReport.Instance;
        public static readonly DocumentCategoryPoliciesAndPlans PoliciesAndPlans = DocumentCategoryPoliciesAndPlans.Instance;
        public static readonly DocumentCategoryMonitoring Monitoring = DocumentCategoryMonitoring.Instance;
        public static readonly DocumentCategoryOther Other = DocumentCategoryOther.Instance;

        public static readonly List<DocumentCategory> All;
        public static readonly ReadOnlyDictionary<int, DocumentCategory> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static DocumentCategory()
        {
            All = new List<DocumentCategory> { MeetingNotes, MeetingAgendas, RequestForProposals, ManualsAndGuidance, Presentations, ProgramInformation, ProgramManagement, ProgressReport, PoliciesAndPlans, Monitoring, Other };
            AllLookupDictionary = new ReadOnlyDictionary<int, DocumentCategory>(All.ToDictionary(x => x.DocumentCategoryID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected DocumentCategory(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder)
        {
            DocumentCategoryID = documentCategoryID;
            DocumentCategoryName = documentCategoryName;
            DocumentCategoryDisplayName = documentCategoryDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int DocumentCategoryID { get; private set; }
        public string DocumentCategoryName { get; private set; }
        public string DocumentCategoryDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return DocumentCategoryID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(DocumentCategory other)
        {
            if (other == null)
            {
                return false;
            }
            return other.DocumentCategoryID == DocumentCategoryID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as DocumentCategory);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return DocumentCategoryID;
        }

        public static bool operator ==(DocumentCategory left, DocumentCategory right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DocumentCategory left, DocumentCategory right)
        {
            return !Equals(left, right);
        }

        public DocumentCategoryEnum ToEnum { get { return (DocumentCategoryEnum)GetHashCode(); } }

        public static DocumentCategory ToType(int enumValue)
        {
            return ToType((DocumentCategoryEnum)enumValue);
        }

        public static DocumentCategory ToType(DocumentCategoryEnum enumValue)
        {
            switch (enumValue)
            {
                case DocumentCategoryEnum.ManualsAndGuidance:
                    return ManualsAndGuidance;
                case DocumentCategoryEnum.MeetingAgendas:
                    return MeetingAgendas;
                case DocumentCategoryEnum.MeetingNotes:
                    return MeetingNotes;
                case DocumentCategoryEnum.Monitoring:
                    return Monitoring;
                case DocumentCategoryEnum.Other:
                    return Other;
                case DocumentCategoryEnum.PoliciesAndPlans:
                    return PoliciesAndPlans;
                case DocumentCategoryEnum.Presentations:
                    return Presentations;
                case DocumentCategoryEnum.ProgramInformation:
                    return ProgramInformation;
                case DocumentCategoryEnum.ProgramManagement:
                    return ProgramManagement;
                case DocumentCategoryEnum.ProgressReport:
                    return ProgressReport;
                case DocumentCategoryEnum.RequestForProposals:
                    return RequestForProposals;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum DocumentCategoryEnum
    {
        MeetingNotes = 1,
        MeetingAgendas = 2,
        RequestForProposals = 3,
        ManualsAndGuidance = 4,
        Presentations = 5,
        ProgramInformation = 6,
        ProgramManagement = 7,
        ProgressReport = 8,
        PoliciesAndPlans = 9,
        Monitoring = 10,
        Other = 11
    }

    public partial class DocumentCategoryMeetingNotes : DocumentCategory
    {
        private DocumentCategoryMeetingNotes(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryMeetingNotes Instance = new DocumentCategoryMeetingNotes(1, @"MeetingNotes", @"Meeting Notes", 10);
    }

    public partial class DocumentCategoryMeetingAgendas : DocumentCategory
    {
        private DocumentCategoryMeetingAgendas(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryMeetingAgendas Instance = new DocumentCategoryMeetingAgendas(2, @"MeetingAgendas", @"Meeting Agendas", 20);
    }

    public partial class DocumentCategoryRequestForProposals : DocumentCategory
    {
        private DocumentCategoryRequestForProposals(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryRequestForProposals Instance = new DocumentCategoryRequestForProposals(3, @"RequestForProposals", @"Request for Proposals", 30);
    }

    public partial class DocumentCategoryManualsAndGuidance : DocumentCategory
    {
        private DocumentCategoryManualsAndGuidance(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryManualsAndGuidance Instance = new DocumentCategoryManualsAndGuidance(4, @"ManualsAndGuidance", @"Manuals and Guidance", 40);
    }

    public partial class DocumentCategoryPresentations : DocumentCategory
    {
        private DocumentCategoryPresentations(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryPresentations Instance = new DocumentCategoryPresentations(5, @"Presentations", @"Presentations", 50);
    }

    public partial class DocumentCategoryProgramInformation : DocumentCategory
    {
        private DocumentCategoryProgramInformation(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryProgramInformation Instance = new DocumentCategoryProgramInformation(6, @"ProgramInformation", @"Program Information", 60);
    }

    public partial class DocumentCategoryProgramManagement : DocumentCategory
    {
        private DocumentCategoryProgramManagement(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryProgramManagement Instance = new DocumentCategoryProgramManagement(7, @"ProgramManagement", @"Program Management", 70);
    }

    public partial class DocumentCategoryProgressReport : DocumentCategory
    {
        private DocumentCategoryProgressReport(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryProgressReport Instance = new DocumentCategoryProgressReport(8, @"ProgressReport", @"Progress Report", 80);
    }

    public partial class DocumentCategoryPoliciesAndPlans : DocumentCategory
    {
        private DocumentCategoryPoliciesAndPlans(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryPoliciesAndPlans Instance = new DocumentCategoryPoliciesAndPlans(9, @"PoliciesAndPlans", @"Policies and Plans", 90);
    }

    public partial class DocumentCategoryMonitoring : DocumentCategory
    {
        private DocumentCategoryMonitoring(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryMonitoring Instance = new DocumentCategoryMonitoring(10, @"Monitoring", @"Monitoring", 100);
    }

    public partial class DocumentCategoryOther : DocumentCategory
    {
        private DocumentCategoryOther(int documentCategoryID, string documentCategoryName, string documentCategoryDisplayName, int sortOrder) : base(documentCategoryID, documentCategoryName, documentCategoryDisplayName, sortOrder) {}
        public static readonly DocumentCategoryOther Instance = new DocumentCategoryOther(11, @"Other", @"Other", 110);
    }
}