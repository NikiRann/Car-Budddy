using CarBuddy.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarBuddy.Data.Models;

namespace CarBuddy.Buisness
{
	public class Controller
	{
		private CarNotesContext context = new CarNotesContext();

		public Controller()
		{
			this.context = new CarNotesContext();
		}

		public void AddCarModel(Car model)
		{
			this.context.Cars.Add(model);
			this.context.SaveChanges();
		}
			
		public Car GetCarModel(int id)
		{
			var car = context.Cars.FirstOrDefault(x => x.Id == id);
			return car;
		}
	}
}
