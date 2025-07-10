using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using task_list_api.Context;
using task_list_api.Dtos;
using task_list_api.Models;
using task_list_api.Utils;

namespace task_list_api.Services.Impl
{
    public class TaskServiceImpl : ITaskService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public TaskServiceImpl(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<TaskDto> SaveTask(TaskReqDto taskReq)
        {
            // Mapear dto a entidad
            TaskModel task = _mapper.Map<TaskModel>(taskReq);
            task.CreatedAt = DateTime.Now;
            task.UpdatedAt = null;

            _appDbContext.Add(task);
            await _appDbContext.SaveChangesAsync();

            // Mapear de entidad a dto
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<PagedResult<TaskDto>> GetPagedTasks(int page, int pageSize)
        {
            var query = _appDbContext.TaskModels.AsQueryable();

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var dtoItems = _mapper.Map<List<TaskDto>>(items);

            return new PagedResult<TaskDto>
            {
                Items = dtoItems,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }


        //public async Task<List<TaskDto>> GetAllTasks()
        //{
        //    List<TaskModel> tasks = await _appDbContext.TaskModels.ToListAsync();
        //    return _mapper.Map<List<TaskDto>>(tasks);
        //}

        public async Task<TaskDto> GetTask(int taskId)
        {
            TaskModel task = await _appDbContext.TaskModels.FindAsync(taskId);

            return task == null ? null : _mapper.Map<TaskDto>(task);
        }


        public async Task<string> UpdateTaskById(int id, TaskReqDto taskUpdate)
        {
            TaskModel existing = await _appDbContext.TaskModels.FindAsync(id);

            if (existing == null)
                return "Tarea no encontrada.";

            try
            {
                _mapper.Map(taskUpdate, existing);
                existing.UpdatedAt = DateTime.Now;

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

                return "Tarea eliminada con éxito.";
            }
            catch (Exception ex)
            {
                return "Ocurrió un error inesperado: " + ex.Message;
            }
        }
    }
}
