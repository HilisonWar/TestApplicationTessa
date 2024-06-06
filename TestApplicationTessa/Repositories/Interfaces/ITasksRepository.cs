using TestApplicationTessa.Models;
using Task = TestApplicationTessa.Models.Task;

namespace TestApplicationTessa.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        public Task GetTaskByPreviousTaskId(int taskId);
    }
}
