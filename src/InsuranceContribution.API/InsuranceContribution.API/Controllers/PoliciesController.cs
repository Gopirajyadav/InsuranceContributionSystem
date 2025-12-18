using InsuranceContribution.Application.DTOs;
using InsuranceContribution.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceContribution.API.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class PoliciesController : ControllerBase
    {
        private readonly IContributionService _service;

        public PoliciesController(IContributionService service)
        {
            _service = service;
        }

        // GET: /api/policies/{policyNumber}/contributions
        [HttpGet("{policyNumber}/contributions")]
        public async Task<IActionResult> GetContributions(string policyNumber)
        {
            try
            {
                ContributionSummaryDto result =
                    await _service.GetContributionsAsync(policyNumber);

                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    Error = "An unexpected error occurred"
                });
            }
        }
    }
}
