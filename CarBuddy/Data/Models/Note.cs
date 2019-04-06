using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarBuddy.Data.Models
{
	public class Note
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [MaxLength(500)]
        public string Text { get; set; }

        //public Car owner { get; set; }
	}
}
