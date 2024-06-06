namespace TestApplicationTessa.Models
{
    public class DocumentDTOGet
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public TaskDTOGet? ActiveTask { get; set; } = null;

        public List<TaskDTOGet> Tasks { get; set; }
    }
}
