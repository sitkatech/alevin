using System;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ObligationRequestModelExtensions
    {
        public static readonly UrlTemplate<int> ObligationRequestDetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(t =>
                t.ObligationRequestDetail(UrlTemplate.Parameter1Int)));

        public static string GetDetailUrl(this ObligationRequest obligationRequest)
        {
            return ObligationRequestDetailUrlTemplate.ParameterReplace(obligationRequest.PrimaryKey);
        }

        public static HtmlString GetDetailLink(this ObligationRequest obligationRequest)
        {
            return UrlTemplate.MakeHrefString(obligationRequest.GetDetailUrl(), obligationRequest.GetObligationRequestNumber());
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));

        public static string GetEditUrl(this ObligationRequest obligationRequest)
        {
            return EditUrlTemplate.ParameterReplace(obligationRequest.PrimaryKey);
        }


        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(t => t.Delete(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this ObligationRequest obligationRequest)
        {
            return DeleteUrlTemplate.ParameterReplace(obligationRequest.PrimaryKey);
        }

        public static string GetRequisitionAge(this ObligationRequest obligationRequest)
        {
            if (obligationRequest.RequisitionDate != null && obligationRequest.ActualAwardDate != null)
            {
                return "Awarded";
            }

            if (obligationRequest.RequisitionDate != null && obligationRequest.ActualAwardDate == null)
            {
                var dateDifference = -((DateTime) obligationRequest.RequisitionDate - DateTime.Now).Days;
                return dateDifference.ToString();
            }

            return "";
        }

        public static string GetRequisitionDeptReviewDays(this ObligationRequest obligationRequest)
        {
            if (obligationRequest.DateSentForDeptReview != null && obligationRequest.ActualAwardDate != null)
            {
                var dateDifference = -((DateTime)obligationRequest.DateSentForDeptReview - (DateTime)obligationRequest.ActualAwardDate).Days;
                return dateDifference.ToString();
            }

            if (obligationRequest.DateSentForDeptReview != null && obligationRequest.ActualAwardDate == null)
            {
                var deptReviewDays = -((DateTime) obligationRequest.DateSentForDeptReview - DateTime.Now).Days;
                return deptReviewDays.ToString();
            }
            
            return "";
        }

        public static string GetRequisitionDaysToAssign(this ObligationRequest obligationRequest)
        {
            if (obligationRequest.RequisitionDate != null && obligationRequest.AssignedDate == null &&
                obligationRequest.ActualAwardDate == null)
            {
                return "Unassigned";
            }

            if (obligationRequest.RequisitionDate != null && obligationRequest.AssignedDate != null)
            {
                var dateDifference =
                    -((DateTime) obligationRequest.RequisitionDate - (DateTime) obligationRequest.AssignedDate).Days;
                return dateDifference.ToString();
            }

            return "";
        }

        public static int? GetRequisitionDaysToAward(this ObligationRequest obligationRequest)
        {
            if (obligationRequest.RequisitionDate != null && obligationRequest.ActualAwardDate != null)
            {
                return -((DateTime)obligationRequest.RequisitionDate - (DateTime)obligationRequest.ActualAwardDate).Days;
            }
            return null;
        }

    }
}