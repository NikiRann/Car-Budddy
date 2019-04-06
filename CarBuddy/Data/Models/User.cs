using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarBuddy.Data.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
		[Required] 
		[MaxLength(20)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(20)]
		public string LastName { get; set; }
        
        //public ICollection<Car> cars { get; set; }

        public User(string username, string first, string last)
        {
            this.Username = username;
            this.FirstName = first;
            this.LastName = last;
        }
        public User()
        {
  
        }
    }
}
