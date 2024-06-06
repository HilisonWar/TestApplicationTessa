using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApplicationTessa.Models
{
	public class Document
	{
		public int Id { get; set; }

		public string Status { get; set; }

		public  virtual List<Task> Tasks { get; set; }

	}
}
