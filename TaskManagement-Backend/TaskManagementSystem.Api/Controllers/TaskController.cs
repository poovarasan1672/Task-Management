using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;

namespace TaskManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("AllTasks")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<List<TaskListItemDto>>))]
        public async Task<IActionResult> GetFilteredTasks()
        {
            try
            {
            var result = await _taskService.GetAllTasksAsync();
            return Ok(GenericResponses<List<ToDoTaskResponseDto>>.SuccessResponse(result));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load TODoTask data"));
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<TaskListItemDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, type: typeof(GenericResponses<string>))]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
            var result = await _taskService.GetTaskByIdAsync(id);
            if (result == null)
                return NotFound(GenericResponses<string>.ErrorResponse("Task not found"));

            return Ok(GenericResponses<ToDoTaskResponseDto>.SuccessResponse(result));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load TODoTask data"));
            }
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<ToDoTaskResponseDto>))]
        public async Task<IActionResult> AddTask([FromBody] AddOrUpdateTaskRequestDto dto)
        {
            try
            {
            var result = await _taskService.AddTaskAsync(dto);
            return Ok(GenericResponses<ToDoTaskResponseDto>.SuccessResponse(result, "Task created successfully"));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load TODoTask data"));
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<ToDoTaskResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, type: typeof(GenericResponses<string>))]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] AddOrUpdateTaskRequestDto dto)
        {
            try
            {
            var result = await _taskService.UpdateTaskAsync(id, dto);
            if (result == null)
                return NotFound(GenericResponses<string>.ErrorResponse("Task not found for update"));

            return Ok(GenericResponses<ToDoTaskResponseDto>.SuccessResponse(result, "Task updated successfully"));
            }

            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load TODoTask data"));
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GenericResponses<string>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, type: typeof(GenericResponses<string>))]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
            var result = await _taskService.DeleteTaskAsync(id);
            if (!result)
                return NotFound(GenericResponses<string>.ErrorResponse("Task not found"));

            return Ok(GenericResponses<string>.SuccessResponse("Task deleted successfully"));
            }
            catch(Exception) {
                return StatusCode(500, GenericResponses<string>.ErrorResponse("Failed to load TODoTask data"));
            }
        }
    }
}