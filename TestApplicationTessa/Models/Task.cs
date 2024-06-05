using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplicationTessa.Models
{
	public class Task
	{
		[Key]
		public int ID { get; set; }

		public string Name { get; set; }

		public int? PreviousTaskId { get; set; }

		public Task? PreviousTask { get; set; }

		public int DocumentId { get; set; }

		[ForeignKey("DocumentId")]
		public Document Document { get;set; }
	}
}
