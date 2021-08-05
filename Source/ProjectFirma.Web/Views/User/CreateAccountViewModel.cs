using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.User
{
    public class CreateAccountViewModel : FormViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Organization")]
        public int OrganizationID { get; set; }


    }
}