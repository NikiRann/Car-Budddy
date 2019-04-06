using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarBuddy.Data.Models
{
	public class Car
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(75)]
		public string Model { get; set; }
        [Required]
        [ForeignKey("User")]
        
        public int OwnerId { get; set; }
  
        

        //public ICollection<Note> notes { get; set; }

	}
}
