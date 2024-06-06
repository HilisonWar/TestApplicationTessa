using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TestApplicationTessa.Models
{
    public class Document
	{
		public int Id { get; set; }

		public string Status { get; set; }

		[ForeignKey("ActiveTask")]
		public int? ActiveTaskId { get; set; }

        public virtual Task? ActiveTask { get; set; }

        public  virtual List<Task> Tasks { get; set; }

    }
}
