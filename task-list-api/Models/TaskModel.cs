using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_list_api.Models
{
    [Table("Task")]
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required]
        [StringLength(50), MinLength(4)]
        public string Title { get; set; }

        [StringLength(150)]
        public string? Description { get; set; }

        [Required]
        public bool Completed { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Required]
        [RegularExpression("low|medium|high")]
        public string Priority { get; set; }

        public string[] Tags { get; set; }
    }
}
