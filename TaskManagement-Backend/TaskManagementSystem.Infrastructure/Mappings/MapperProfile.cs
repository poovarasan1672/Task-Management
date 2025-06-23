using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;
using TaskManagementSystem.Data.Model;

namespace TaskManagementSystem.Infrastructure.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ToDoTask, TaskListItemDto>()
            .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.Project.Title))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Project.User.Name));
            CreateMap<AddOrUpdateTaskRequestDto, ToDoTask>();
            CreateMap<ToDoTask, ToDoTaskResponseDto>()
                .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.Project.Title))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Project.User.Name));
            CreateMap<AddOrUpdateProjectRequestDto, Project>();
            CreateMap<Project, ProjectResponseDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
            CreateMap<AddOrUpdateUserRequestDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}
