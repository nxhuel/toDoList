using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_list_api.Models
{
    [Table("Task")]
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public required string? Description { get; set; }

        [Required]
        public required bool Completed { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Required]
        [RegularExpression("low|medium|high")]
        public required string Priority { get; set; }

        public string[]? Tags { get; set; }

        // se encarga el sistema
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        // seguridad
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
