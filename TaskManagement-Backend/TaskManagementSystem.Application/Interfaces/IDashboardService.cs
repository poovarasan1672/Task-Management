using TaskManagementSystem.Common.Responses;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetSummaryAsync();
    }
}