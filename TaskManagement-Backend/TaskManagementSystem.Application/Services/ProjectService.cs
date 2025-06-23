using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Data.Model;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;
using TaskManagementSystem.Data.Repositories.Interface;

namespace TaskManagementSystem.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<List<ProjectResponseDto>> GetAllProjectsAsync()
        {
            var projects = await _projectRepo.GetProjectsWithTasksAsync();
            return _mapper.Map<List<ProjectResponseDto>>(projects);
        }
        public async Task<ProjectResponseDto> AddProjectAsync(AddOrUpdateProjectRequestDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            var created = await _projectRepo.AddAsync(project);
            return _mapper.Map<ProjectResponseDto>(created);
        }

    }
}
