using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Common.Responses;
namespace TaskManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<DashboardSummaryDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(GenericResponses<string>))]
        public async Task<IActionResult> GetDashboard()
        {
            try
            {
                var summary = await _dashboardService.GetSummaryAsync();
                return Ok(GenericResponses<DashboardSummaryDto>.SuccessResponse(summary));
            }
            catch (Exception)
            {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load dashboard data"));
            }
        }
    }
}

