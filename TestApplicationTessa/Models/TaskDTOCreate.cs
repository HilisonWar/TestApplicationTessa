using System.ComponentModel.DataAnnotations;

namespace TestApplicationTessa.Models
{
    public class TaskDTOCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
