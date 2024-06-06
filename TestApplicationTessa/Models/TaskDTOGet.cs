namespace TestApplicationTessa.Models
{
    public class TaskDTOGet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? PreviousTaskId { get; set; }
    }
}
