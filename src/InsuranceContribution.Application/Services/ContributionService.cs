using InsuranceContribution.Application.DTOs;
using InsuranceContribution.Application.Validators;
using InsuranceContribution.Domain.Entities;
using InsuranceContribution.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InsuranceContribution.Application.Services
{
    public class ContributionService : IContributionService
    {
        private readonly InsuranceDbContext _context;

        public ContributionService(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task CreateContributionAsync(ContributionRequestDto dto)
        {
            try
            {
                ContributionValidator.Validate(dto);

                var policy = await _context.Policies
                    .FirstOrDefaultAsync(p => p.PolicyNumber == dto.PolicyNumber);

                if (policy == null)
                    throw new ApplicationException("Policy not found");

                bool exists = await _context.Contributions
                    .AnyAsync(c => c.TransactionRef == dto.TransactionRef);

                if (exists)
                    throw new ApplicationException("Duplicate transaction reference");

                var contribution = new Contribution
                {
                    PolicyId = policy.PolicyId,
                    PremiumAmount = dto.PremiumAmount,
                    ContributionDate = dto.ContributionDate,
                    TransactionRef = dto.TransactionRef
                };

                _context.Contributions.Add(contribution);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public async Task<ContributionSummaryDto> GetContributionsAsync(string policyNumber)
        {
            var contributions = await _context.Contributions
                .Include(c => c.Policy)
                .Where(c => c.Policy.PolicyNumber == policyNumber)
                .ToListAsync();

            return new ContributionSummaryDto
            {
                PolicyNumber = policyNumber,
                TotalPremium = contributions.Sum(x => x.PremiumAmount),
                ContributionCount = contributions.Count
            };
        }
    }
}
