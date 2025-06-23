namespace TaskManagementSystem.Common.Responses
{
    public class DashboardSummaryDto
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int OverdueTasks { get; set; }
    }
}