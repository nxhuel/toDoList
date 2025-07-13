using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_list_api.Context;
using task_list_api.Mappings;

namespace task_list_api_test
{
    public class TestBase
    {
        protected AppDbContext Context(string nameDb)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(nameDb).Options;

            var dbContext = new AppDbContext(options);

            return dbContext;
        }

        protected IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile<MappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}
