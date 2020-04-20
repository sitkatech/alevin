using ProjectFirmaModels.Models;
using System.Linq;

namespace ProjectFirma.Api.Models
{
    public class FundingSourceFinancialTotalsDto
    {
        public FundingSourceFinancialTotalsDto(FundingSource fundingSource, IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            ProjectFirmaFundingSourceID = fundingSource.FundingSourceID;
            ExpendituresTotal = projectFundingSourceExpenditures.Any() ? projectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?) null;
        }

        public FundingSourceFinancialTotalsDto()
        {
        }

        public int ProjectFirmaFundingSourceID { get; set; }
        public decimal? ExpendituresTotal { get; set; }
    }


}