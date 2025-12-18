using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceContribution.Application.DTOs;

namespace InsuranceContribution.Application.Validators
{
    public static class ContributionValidator
    {
        public static void Validate(ContributionRequestDto dto)
        {
            if (dto.PremiumAmount <= 0)
                throw new ArgumentException("Premium amount must be greater than zero");

            if (string.IsNullOrWhiteSpace(dto.TransactionRef))
                throw new ArgumentException("Transaction reference is required");
        }
    }
}
