using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceContribution.Application.DTOs;

namespace InsuranceContribution.Application.Services
{
    public interface IContributionService
    {
        Task CreateContributionAsync(ContributionRequestDto dto);
        Task<ContributionSummaryDto> GetContributionsAsync(string policyNumber);
    }

}
