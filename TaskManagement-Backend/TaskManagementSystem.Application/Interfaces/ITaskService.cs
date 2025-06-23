using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<ToDoTaskResponseDto>> GetAllTasksAsync();
        Task<ToDoTaskResponseDto> GetTaskByIdAsync(int id);
        Task<ToDoTaskResponseDto> AddTaskAsync(AddOrUpdateTaskRequestDto dto);
        Task<ToDoTaskResponseDto> UpdateTaskAsync(int id, AddOrUpdateTaskRequestDto dto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
