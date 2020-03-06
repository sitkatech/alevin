using System;
using DocumentFormat.OpenXml.Wordprocessing;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class AgreementRequestModelExtensions
    {
        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t =>
                t.AgreementRequestDetail(UrlTemplate.Parameter1Int)));

        public static string GetDetailUrl(this AgreementRequest agreementRequest)
        {
            return DetailUrlTemplate.ParameterReplace(agreementRequest.PrimaryKey);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));

        public static string GetEditUrl(this AgreementRequest agreementRequest)
        {
            return EditUrlTemplate.ParameterReplace(agreementRequest.PrimaryKey);
        }


        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.Delete(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this AgreementRequest agreementRequest)
        {
            return DeleteUrlTemplate.ParameterReplace(agreementRequest.PrimaryKey);
        }

        public static string GetRequisitionAge(this AgreementRequest agreementRequest)
        {
            if (agreementRequest.RequisitionDate != null && agreementRequest.ActualAwardDate != null)
            {
                return "Awarded";
            }

            if (agreementRequest.RequisitionDate != null && agreementRequest.ActualAwardDate == null)
            {
                var dateDifference = -((DateTime) agreementRequest.RequisitionDate - DateTime.Now).Days;
                return dateDifference.ToString();
            }

            return "";
        }

        public static string GetRequisitionDeptReviewDays(this AgreementRequest agreementRequest)
        {
            if (agreementRequest.DateSentForDeptReview != null && agreementRequest.ActualAwardDate != null)
            {
                var dateDifference = -((DateTime)agreementRequest.DateSentForDeptReview - (DateTime)agreementRequest.ActualAwardDate).Days;
                return dateDifference.ToString();
            }

            if (agreementRequest.DateSentForDeptReview != null && agreementRequest.ActualAwardDate == null)
            {
                var deptReviewDays = -((DateTime) agreementRequest.DateSentForDeptReview - DateTime.Now).Days;
                return deptReviewDays.ToString();
            }
            
            return "";
        }

        public static string GetRequisitionDaysToAssign(this AgreementRequest agreementRequest)
        {
            if (agreementRequest.RequisitionDate != null && agreementRequest.AssignedDate == null &&
                agreementRequest.ActualAwardDate == null)
            {
                return "Unassigned";
            }

            if (agreementRequest.RequisitionDate != null && agreementRequest.AssignedDate != null)
            {
                var dateDifference =
                    -((DateTime) agreementRequest.RequisitionDate - (DateTime) agreementRequest.AssignedDate).Days;
                return dateDifference.ToString();
            }

            return "";
        }

        public static int? GetRequisitionDaysToAward(this AgreementRequest agreementRequest)
        {
            if (agreementRequest.RequisitionDate != null && agreementRequest.ActualAwardDate != null)
            {
                return -((DateTime)agreementRequest.RequisitionDate - (DateTime)agreementRequest.ActualAwardDate).Days;
            }
            return null;
        }

    }
}