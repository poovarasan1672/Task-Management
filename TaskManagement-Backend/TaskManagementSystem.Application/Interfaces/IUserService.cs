using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Common.Responses;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUserAsync();
        Task<UserResponseDto> AddUserAsync(AddOrUpdateUserRequestDto dto);
 
    }
}
