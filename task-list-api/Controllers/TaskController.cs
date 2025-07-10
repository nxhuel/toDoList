using Microsoft.AspNetCore.Mvc;
using task_list_api.Dtos;
using task_list_api.Models;
using task_list_api.Services;
using task_list_api.Utils;

namespace task_list_api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> SaveTask([FromBody] TaskReqDto taskSave)
        {
            TaskDto savedTask = await _taskService.SaveTask(taskSave);
            return CreatedAtAction(nameof(GetTaskById), new { id = savedTask.TaskId }, savedTask);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<TaskDto>>> GetTasks(int page = 1, int pageSize = 10)
        {
            var result = await _taskService.GetPagedTasks(page, pageSize);
            return Ok(result);
        }



        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        //{
        //    List<TaskDto> taskList = await _taskService.GetAllTasks();
        //    return Ok(taskList);
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(int id)
        {
            var task = await _taskService.GetTask(id);

            if (task == null) return NotFound();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTaskById(int id, [FromBody] TaskReqDto taskUpdate)
        {

            string taskUpdated = await _taskService.UpdateTaskById(id, taskUpdate);

            if (taskUpdated.Contains("no encontrada"))
                return NotFound(taskUpdated);

            return Ok(taskUpdated);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTaskById(int id)
        {
            string taskDeleted = await _taskService.DeleteTaskById(id);

            if (taskDeleted.Contains("no encontrada"))
                return NotFound(taskDeleted);

            return Ok(taskDeleted);
        }
    }
}
