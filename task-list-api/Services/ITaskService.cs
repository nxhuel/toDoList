using task_list_api.Dtos;

namespace task_list_api.Services
{
    public interface ITaskService
    {
        public Task<TaskDto> SaveTask(TaskReqDto taskReq);

        public Task<List<TaskDto>> GetAllTasks();

        public Task<TaskDto> GetTask(int taskId);

        public Task<string> UpdateTaskById(int id, TaskReqDto taskUpdate);

        public Task<string> DeleteTaskById(int id);

    }
}
