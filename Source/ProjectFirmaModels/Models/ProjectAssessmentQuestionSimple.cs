﻿/*-----------------------------------------------------------------------
<copyright file="ProjectAssessmentQuestionSimple.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
namespace ProjectFirmaModels.Models
{
    public class ProjectAssessmentQuestionSimple
    {
        public int ProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectAssessmentQuestionSimple()
        {
        }

        //Build a simple for a question that has already been answered
        public ProjectAssessmentQuestionSimple(ProjectAssessmentQuestion projectAssessmentQuestion)
        {
            ProjectID = projectAssessmentQuestion.ProjectID;
            AssessmentQuestionID = projectAssessmentQuestion.AssessmentQuestionID;
            Answer = projectAssessmentQuestion.Answer;
        }


        //Build a simple when we only have the question, but no answer
        public ProjectAssessmentQuestionSimple(AssessmentQuestion assessmentQuestion, Project project)
        {
            AssessmentQuestionID = assessmentQuestion.AssessmentQuestionID;
            ProjectID = project.ProjectID;
            Answer = null;
        }
    }
}
