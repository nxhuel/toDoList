using System.ComponentModel.DataAnnotations;

namespace task_list_api.Dtos
{
    public class TaskDto
    {
        public int TaskId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime DueDate { get; set; }

        public string Priority { get; set; }

        public string[] Tags { get; set; }
    }
}
