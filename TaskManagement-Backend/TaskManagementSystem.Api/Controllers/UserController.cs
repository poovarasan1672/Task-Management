using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Application.Services;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;

namespace TaskManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<List<UserResponseDto>>))]
        public async Task<IActionResult> GetAllUse()
        {
            try { 
                var result = await _userService.GetAllUserAsync();
                return Ok(GenericResponses<List<UserResponseDto>>.SuccessResponse(result));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load User data"));
            }
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<UserResponseDto>))]
        public async Task<IActionResult> AddUser([FromBody] AddOrUpdateUserRequestDto dto)
        {
            try
            {
            var result = await _userService.AddUserAsync(dto);
            return Ok(GenericResponses<UserResponseDto>.SuccessResponse(result, "User created successfully"));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load User data"));
            }
        }
    }
}