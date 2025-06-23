using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;
using TaskManagementSystem.Data.Model;
using TaskManagementSystem.Data.Repositories.Interface;

namespace TaskManagementSystem.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepo, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _mapper = mapper;
        }

        public async Task<List<ToDoTaskResponseDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepo.GetAllTasksAsync();
            return _mapper.Map<List<ToDoTaskResponseDto>>(tasks);
        }
        public async Task<ToDoTaskResponseDto> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            return _mapper.Map<ToDoTaskResponseDto>(task);
        }

        public async Task<ToDoTaskResponseDto> AddTaskAsync(AddOrUpdateTaskRequestDto dto)
        {
            var task = _mapper.Map<ToDoTask>(dto);
            var created = await _taskRepo.AddAsync(task);
            return _mapper.Map<ToDoTaskResponseDto>(created);
        }

        public async Task<ToDoTaskResponseDto> UpdateTaskAsync(int id, AddOrUpdateTaskRequestDto dto)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null) throw new Exception("Task not found");

            // update fields
            task.TaskName = dto.TaskName;
            task.DueDate = dto.DueDate;
            task.IsCompleted = dto.IsCompleted;
            task.ProjectId = dto.ProjectId;

            var updated = await _taskRepo.UpdateAsync(task);
            return _mapper.Map<ToDoTaskResponseDto>(updated);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepo.DeleteAsync(id);
        }

    }

}
