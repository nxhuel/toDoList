using Microsoft.AspNetCore.Mvc;

using task_list_api.Controllers;
using task_list_api.Dtos;
using task_list_api.Models;
using task_list_api.Services.Impl;
using task_list_api.Utils;

namespace task_list_api_test.Controllers
{
    [TestClass]
    public sealed class TaskControllerTest : TestBase
    {
        [TestMethod]
        public async Task Get_GetTasks()
        {
            // Preparacion
            var nameDb = Guid.NewGuid().ToString();
            var context = Context(nameDb);
            var mapper = ConfigureAutoMapper();

            context.TaskModels.Add(new TaskModel()
            {
                Title = "Task 1000",
                Priority = "medium",
                Tags = new string[] { "urgent" }
            });
            context.TaskModels.Add(new TaskModel()
            {
                Title = "Task 2000",
                Priority = "medium",
                Tags = new string[] { "normal" }
            });

            await context.SaveChangesAsync();

            var context2 = Context(nameDb);
            var service = new TaskServiceImpl(context2, mapper);
            var controller = new TaskController(service);

            // ejecucion
            var response = await controller.GetTasks();

            // verificacion
            var result = response.Result as OkObjectResult;
            var pagedResult = result?.Value as PagedResult<TaskDto>;

            Assert.IsNotNull(pagedResult);
            Assert.AreEqual(2, pagedResult.Items.Count);
        }

    }
}
