using TestApplicationTessa.Models;
using TestApplicationTessa.Repositories.Interfaces;

namespace TestApplicationTessa.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private DataBaseContext _dbContext;

        public TasksRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Models.Task GetTaskByPreviousTaskId(int taskId)
        {
            return _dbContext.Tasks.FirstOrDefault(task => task.PreviousTaskId == taskId);
        }
    }
}
