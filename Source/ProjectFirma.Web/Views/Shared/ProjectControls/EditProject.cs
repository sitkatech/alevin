﻿/*-----------------------------------------------------------------------
<copyright file="EditProject.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class EditProject : TypedWebPartialViewPage<EditProjectViewData, EditProjectViewModel>
    {
    }

    public abstract class EditProjectType
    {
        public readonly string IntroductoryText;

        internal EditProjectType(string introductoryText)
        {
            IntroductoryText = introductoryText;
        }

        public static readonly EditProjectTypeNewProject NewProject = EditProjectTypeNewProject.Instance;
        public static readonly EditProjectTypeExistingProject ExistingProject = EditProjectTypeExistingProject.Instance;
        public static readonly EditProjectTypeProposal Proposal = EditProjectTypeProposal.Instance;
    }

    public class EditProjectTypeNewProject : EditProjectType
        {
        private EditProjectTypeNewProject(string introductoryText) : base(introductoryText) {  }
            public static readonly EditProjectTypeNewProject Instance = new EditProjectTypeNewProject($"<p>Enter basic information about the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}.</p>");
        }

    public class EditProjectTypeExistingProject : EditProjectType
        {
            private EditProjectTypeExistingProject(string introductoryText) : base(introductoryText) { }
            public static readonly EditProjectTypeExistingProject Instance = new EditProjectTypeExistingProject($"<p>Update this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}'s information.</p>");
        }

    public class EditProjectTypeProposal : EditProjectType
    {
        private EditProjectTypeProposal(string introductoryText) : base(introductoryText) { }
        public static readonly EditProjectTypeProposal Instance = new EditProjectTypeProposal($"<p>Enter additional information to approve this as a full-fledged {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}.</p>");
    }
}
