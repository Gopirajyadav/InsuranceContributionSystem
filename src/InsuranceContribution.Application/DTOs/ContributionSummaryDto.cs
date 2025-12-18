using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContribution.Application.DTOs
{
    public class ContributionSummaryDto
    {
        public string PolicyNumber { get; set; } = null!;
        public decimal TotalPremium { get; set; }
        public int ContributionCount { get; set; }
    }
}
