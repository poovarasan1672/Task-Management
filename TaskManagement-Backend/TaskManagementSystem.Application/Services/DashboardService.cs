using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Common.Responses;
using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Repositories.Interface;

namespace TaskManagementSystem.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardSummaryDto> GetSummaryAsync()
        {
            return new DashboardSummaryDto
            {
                TotalTasks = await _dashboardRepository.GetTotalTasksAsync(),
                CompletedTasks = await _dashboardRepository.GetCompletedTasksAsync(),
                OverdueTasks = await _dashboardRepository.GetOverdueTasksAsync()
            };
        }
    }
}
