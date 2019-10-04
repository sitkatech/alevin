﻿/*-----------------------------------------------------------------------
<copyright file="AssessmentQuestion.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class AssessmentQuestion : IAuditableEntity
    {
        public bool IsArchived() => ArchiveDate.HasValue;

        public string GetAuditDescriptionString()
        {
            return $"Question: {AssessmentQuestionID}";
        }

        public int GetCountOfYesAnswers()
        {
            return ProjectAssessmentQuestions.Count(x => x.Answer ?? false) + ProjectAssessmentQuestions.Count(x => x.Answer ?? false);
        }

        public int GetCountOfNoAnswers()
        {
            return ProjectAssessmentQuestions.Count(x => !x.Answer ?? false) + ProjectAssessmentQuestions.Count(x => !x.Answer ?? false);
        }
    }
}
