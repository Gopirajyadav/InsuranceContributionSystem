using InsuranceContribution.Application.DTOs;
using InsuranceContribution.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceContribution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionsController : ControllerBase
    {
        private readonly IContributionService _service;

        public ContributionsController(IContributionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContributionRequestDto dto)
        {
            try
            {
                await _service.CreateContributionAsync(dto);
                return Ok(new { Message = "Contribution processed successfully" });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
