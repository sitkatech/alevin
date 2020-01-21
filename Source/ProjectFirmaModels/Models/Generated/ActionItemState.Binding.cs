//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionItemState]
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
    public abstract partial class ActionItemState : IHavePrimaryKey
    {
        public static readonly ActionItemStateIncomplete Incomplete = ActionItemStateIncomplete.Instance;
        public static readonly ActionItemStateComplete Complete = ActionItemStateComplete.Instance;

        public static readonly List<ActionItemState> All;
        public static readonly ReadOnlyDictionary<int, ActionItemState> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ActionItemState()
        {
            All = new List<ActionItemState> { Incomplete, Complete };
            AllLookupDictionary = new ReadOnlyDictionary<int, ActionItemState>(All.ToDictionary(x => x.ActionItemStateID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ActionItemState(int actionItemStateID, string actionItemStateName, string actionItemStateDisplayName, int sortOrder)
        {
            ActionItemStateID = actionItemStateID;
            ActionItemStateName = actionItemStateName;
            ActionItemStateDisplayName = actionItemStateDisplayName;
            SortOrder = sortOrder;
        }

        [Key]
        public int ActionItemStateID { get; private set; }
        public string ActionItemStateName { get; private set; }
        public string ActionItemStateDisplayName { get; private set; }
        public int SortOrder { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ActionItemStateID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ActionItemState other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ActionItemStateID == ActionItemStateID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ActionItemState);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ActionItemStateID;
        }

        public static bool operator ==(ActionItemState left, ActionItemState right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActionItemState left, ActionItemState right)
        {
            return !Equals(left, right);
        }

        public ActionItemStateEnum ToEnum { get { return (ActionItemStateEnum)GetHashCode(); } }

        public static ActionItemState ToType(int enumValue)
        {
            return ToType((ActionItemStateEnum)enumValue);
        }

        public static ActionItemState ToType(ActionItemStateEnum enumValue)
        {
            switch (enumValue)
            {
                case ActionItemStateEnum.Complete:
                    return Complete;
                case ActionItemStateEnum.Incomplete:
                    return Incomplete;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ActionItemStateEnum
    {
        Incomplete = 1,
        Complete = 2
    }

    public partial class ActionItemStateIncomplete : ActionItemState
    {
        private ActionItemStateIncomplete(int actionItemStateID, string actionItemStateName, string actionItemStateDisplayName, int sortOrder) : base(actionItemStateID, actionItemStateName, actionItemStateDisplayName, sortOrder) {}
        public static readonly ActionItemStateIncomplete Instance = new ActionItemStateIncomplete(1, @"Incomplete", @"Incomplete", 10);
    }

    public partial class ActionItemStateComplete : ActionItemState
    {
        private ActionItemStateComplete(int actionItemStateID, string actionItemStateName, string actionItemStateDisplayName, int sortOrder) : base(actionItemStateID, actionItemStateName, actionItemStateDisplayName, sortOrder) {}
        public static readonly ActionItemStateComplete Instance = new ActionItemStateComplete(2, @"Complete", @"Complete", 20);
    }
}