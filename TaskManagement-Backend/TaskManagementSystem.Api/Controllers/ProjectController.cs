using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;


namespace TaskManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAllProjects")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<List<ProjectResponseDto>>))]
        public async Task<IActionResult> GetAllProjects()
        {
            try { 
                var result = await _projectService.GetAllProjectsAsync();
                return Ok(GenericResponses<List<ProjectResponseDto>>.SuccessResponse(result));
            }
           
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load project data"));
            }
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<ProjectResponseDto>))]
        public async Task<IActionResult> AddProject([FromBody] AddOrUpdateProjectRequestDto dto)
        {
            try
            {
                var result = await _projectService.AddProjectAsync(dto);
                return Ok(GenericResponses<ProjectResponseDto>.SuccessResponse(result, "Project added successfully"));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load project data"));
            }
        }

     
    }
}