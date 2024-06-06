namespace TestApplicationTessa.API_Models
{
	public class DocumentForm
	{
		public int ID { get; set; }

		public string Status { get; set; }

		public TaskForm? ActiveTask { get; set; }
       
		public List<TaskForm> Tasks { get; set; }
	}

	public class TaskForm
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public int? PreviousTaskId { get; set; }
	}

}
