﻿/*-----------------------------------------------------------------------
<copyright file="EditUserViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DocumentFormat.OpenXml.Bibliography;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using Person = ProjectFirmaModels.Models.Person;

namespace ProjectFirma.Web.Views.User
{
    public class EditUserViewModel : FormViewModel
    {
        [Required] 
        public int PersonID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public int OrganizationID { get; set; }

        [Required]
        public string Username { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditUserViewModel()
        {
        }

        public EditUserViewModel(Person person)
        {
            PersonID = person.PersonID;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            PhoneNumber = person.Phone;
            OrganizationID = person.OrganizationID;
            Username = person.LoginName;

        }

        public void UpdateModel(Person personBeingEdited, FirmaSession currentFirmaSession)
        {

        }
    }
}
