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
using TaskManagementSystem.Data.Repositories;
using TaskManagementSystem.Data.Repositories.Interface;

namespace TaskManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<UserResponseDto>> GetAllUserAsync()
        {
            var user = await _userRepo.GetAllUserAsync();
            return _mapper.Map<List<UserResponseDto>>(user);
        }

        public async Task<UserResponseDto> AddUserAsync(AddOrUpdateUserRequestDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var created = await _userRepo.AddAsync(user);
            return _mapper.Map<UserResponseDto>(created);
        }

    }

}
