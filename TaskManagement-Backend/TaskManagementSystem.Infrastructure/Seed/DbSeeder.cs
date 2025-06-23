using TaskManagementSystem.Data;
using TaskManagementSystem.Data.Model;

namespace TaskManagementSystem.Infrastructure.Seed
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();    
            context.Database.EnsureCreated();    

            if (!context.Users.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var user = new User
                    {
                        Name = $"User {i}"
                    };
                    context.Users.Add(user);
                    context.SaveChanges(); 

                    var project = new Project
                    {
                        Title = $"Project {i}",
                        Description = $"Setup tasks for Project {i}",
                        UserId = user.Id
                    };
                    context.Projects.Add(project);
                    context.SaveChanges(); 

                    var task1 = new ToDoTask
                    {
                        TaskName = $"Task A for Project {i}",
                        DueDate = DateTime.Today.AddDays(i),
                        IsCompleted = false,
                        ProjectId = project.Id
                    };

                    var task2 = new ToDoTask
                    {
                        TaskName = $"Task B for Project {i}",
                        DueDate = DateTime.Today.AddDays(i + 2),
                        IsCompleted = i % 2 == 0, 
                        ProjectId = project.Id
                    };

                    context.ToDoTasks.AddRange(task1, task2);
                    context.SaveChanges();
                }
            }
        }
    }
}
