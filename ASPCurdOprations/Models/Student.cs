using System.ComponentModel.DataAnnotations;

namespace ASPCurdOprations.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]

        public int Id { set;get; }
        [Required]
        public string? Name { set; get; }
        [Required]

        public string? Course { set; get; }
        [Required]

        public string? Duration { set; get; }
        [ScaffoldColumn(false)]

        public int isActive { set; get; }
    }
}
