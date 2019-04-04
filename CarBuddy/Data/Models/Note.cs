using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarBuddy.Data.Models
{
	public class Note
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
	}
}
