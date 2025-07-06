using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using task_list_api.Context;
using task_list_api.Dtos;
using task_list_api.Models;

namespace task_list_api.Services.Impl
{
    public class TaskServieImpl : ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskServieImpl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Corregir logica POST : no detecta  descripcion, fechas, priority y tags
        public async Task<TaskDto> SaveTask(TaskReqDto taskReq)
        {


            TaskModel task = new()
            {
                Title = taskReq.Title,
                Description = taskReq.Description,
                Completed = taskReq.Completed,
                CreatedAt = DateTime.UtcNow,
                DueDate = taskReq.DueDate,
                Priority = taskReq.Priority,
                Tags = taskReq.Tags
            };

            _appDbContext.TaskModels.Add(task);

            await _appDbContext.SaveChangesAsync();
            return new TaskDto { TaskId = task.TaskId, Title = task.Title };
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            return await _appDbContext.TaskModels
                .Select(task => new TaskDto
                {
                    TaskId = task.TaskId,
                    Title = task.Title,
                    Description = task.Description,
                    Completed = task.Completed,
                    CreatedAt = (DateTime)task.CreatedAt,
                    UpdatedAt = (DateTime)task.UpdatedAt,
                    DueDate = (DateTime)task.DueDate,
                    Priority = task.Priority,
                    Tags = task.Tags,
                })
                .ToListAsync();
        }

        public async Task<TaskDto> GetTask(int taskId)
        {
            var task = await _appDbContext.TaskModels.FindAsync(taskId);

            if (task == null) return null;

            return new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                Completed = task.Completed,
                CreatedAt = (DateTime)task.CreatedAt,
                UpdatedAt = (DateTime)task.UpdatedAt,
                DueDate = (DateTime)task.DueDate,
                Priority = task.Priority,
                Tags = task.Tags,

            };
        }


        public async Task<string> UpdateTaskById(int id, TaskReqDto taskUpdate)
        {
            var existing = await _appDbContext.TaskModels.FindAsync(id);

            if (existing == null)
                return "Tarea no encontrada.";


            try
            {
                existing.Title = taskUpdate.Title;
                existing.Description = taskUpdate.Description;
                existing.Completed = taskUpdate.Completed;
                existing.UpdatedAt = DateTime.UtcNow;
                existing.DueDate = taskUpdate.DueDate;
                existing.Priority = taskUpdate.Priority;
                existing.Tags = taskUpdate.Tags;

                await _appDbContext.SaveChangesAsync();
                return "Tarea actualizada con exito.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> DeleteTaskById(int id)
        {
            var existing = await _appDbContext.TaskModels.FindAsync(id);

            if (existing == null)
                return "Tarea no encontrada.";

            try
            {
                _appDbContext.TaskModels.Remove(existing);
                await _appDbContext.SaveChangesAsync();

                return "Tarea elimina con exito.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
