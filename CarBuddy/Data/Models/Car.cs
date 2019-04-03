using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarBuddy.Data.Models
{
	public class Car
	{
		//[Key]
		public int Id { get; set; }
		//[Required]
		public string Model { get; set; }
	}
}
