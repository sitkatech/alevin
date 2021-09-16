using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Admin
{
    public abstract class UpdateSite : TypedWebViewPage<UpdateSiteViewData, UpdateSiteViewModel>
    {
    }

    public class UpdateSiteViewData : FirmaViewData
    {
        public readonly string BackUrl;
        
        public UpdateSiteViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Update Site";
        }
    }

    public class UpdateSiteViewModel : IValidatableObject
    {        
        [DisplayName("Posted file")]
        public HttpPostedFileBase PostedFileBase { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            const string postedfilebase = "PostedFileBase";
            if (PostedFileBase == null)
            {
                errors.Add(new ValidationResult("Please upload a file", new[] { postedfilebase }));
            }
            else if (PostedFileBase.ContentLength == 0)
            {
                errors.Add(new ValidationResult("File uploaded was empty", new[] { postedfilebase}));
            }
            else if (PostedFileBase.ContentLength > 0)
            {
                // More validation could go here
            }
            return errors;
        }
    }
}