using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplicationTessa.Models
{
	public class Task
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[ForeignKey("PreviousTask")]
		public int? PreviousTaskId { get; set; } = null;
        public virtual Task? PreviousTask { get; set; } = null;

        [ForeignKey("Document")]
		public int? DocumentId { get; set; } = null;
		public  virtual Document? Document { get; set; } = null;

		public virtual Document? ActiveTaskDocument { get; set; } = null;

        

    }

}
