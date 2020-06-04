//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AssessmentGoal
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AssessmentGoalPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AssessmentGoal>
    {
        public AssessmentGoalPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AssessmentGoalPrimaryKey(AssessmentGoal assessmentGoal) : base(assessmentGoal){}

        public static implicit operator AssessmentGoalPrimaryKey(int primaryKeyValue)
        {
            return new AssessmentGoalPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AssessmentGoalPrimaryKey(AssessmentGoal assessmentGoal)
        {
            return new AssessmentGoalPrimaryKey(assessmentGoal);
        }
    }
}