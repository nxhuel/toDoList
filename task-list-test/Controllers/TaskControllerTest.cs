using Microsoft.AspNetCore.Mvc;

using task_list_api.Controllers;
using task_list_api.Models;
using task_list_api.Services.Impl;
using task_list_api_test;

namespace task_list_test.Controllers
{
    public class TaskControllerTest : TestBase
    {
        [Fact]
        public async Task Get_GetTasks_OK()
        {
            // preparacion individual
            var nameDb = Guid.NewGuid().ToString();
            var context = Context(nameDb);
            var mapper = ConfigureAutoMapper();

            context.TaskModels.Add(new TaskModel()
            {
                TaskId = 1,
                Title = "Task 1000",
                Priority = "medium",
                Tags = new string[] { "urgent" }
            });
            context.TaskModels.Add(new TaskModel()
            {
                TaskId = 2,
                Title = "Task 2000",
                Priority = "medium",
                Tags = new string[] { "normal" }
            });

            await context.SaveChangesAsync();

            var context2 = Context(nameDb);
            var service = new TaskServiceImpl(context2, mapper);
            var controller = new TaskController(service);

            // ejecucion
            var result = await controller.GetTasks();

            // verificacion
            Assert.IsType<OkObjectResult>(result.Result);
        }

    }
}
