using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectResponseDto>> GetAllProjectsAsync();
        Task<ProjectResponseDto> AddProjectAsync(AddOrUpdateProjectRequestDto dto);
    }
}
