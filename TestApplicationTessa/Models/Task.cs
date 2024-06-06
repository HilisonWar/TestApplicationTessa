using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplicationTessa.Models
{
	public class Task
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsActiveTask { get; set; }

		[ForeignKey("PreviousTask")]
		public int? PreviousTaskId { get; set; } = null;

		public Task? PreviousTask { get; set; } = null;

		[ForeignKey("Document")]
		public int? DocumentId { get; set; } = null;

		public Document? Document { get; set; } = null;

	}
}
