using Microsoft.AspNetCore.Identity;

namespace task_list_api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<TaskModel>? Tasks { get; set; }
    }
}
