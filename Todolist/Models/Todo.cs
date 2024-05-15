
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todolist.Models
{
	public class Todo
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(30)]
		public string Task { get; set; }
		[Required]
		[DisplayName("Dead Line")]
		public string Deadline { get; set; }
	}
}
