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
                Title = "Task 1000",
                Description = "Descripcion cualq",
                Completed = true,
                Priority = "medium",
                Tags = new string[] { "urgent" }
            });
            context.TaskModels.Add(new TaskModel()
            {
                Title = "Task 2000",
                Description = "Descripcion cualq",
                Completed = false,
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

        [Fact]
        public async Task Get_GetTasks_IsNull()
        {
            // preparacion individual
            var nameDb = Guid.NewGuid().ToString();
            var context = Context(nameDb);
            var mapper = ConfigureAutoMapper();

            var context2 = Context(nameDb);
            var service = new TaskServiceImpl(context2, mapper);
            var controller = new TaskController(service);

            // ejecucion
            var result = await controller.GetTasks();

            // verificacion
            Assert.IsType<NotFoundObjectResult>(result.Result);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("No tasks found", notFoundResult.Value);
        }

    }
}
