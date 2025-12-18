using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContribution.Application.DTOs
{
    public class ContributionResponseDto
    {
        public int ContributionId { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime ContributionDate { get; set; }
        public string TransactionRef { get; set; } = null!;
    }

}
