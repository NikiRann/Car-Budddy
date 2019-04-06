using CarBuddy.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarBuddy.Data.Models;

namespace CarBuddy.Buisness
{
	public class UserController
	{
        public User currentUser;

		private CarNotesContext context;

		public UserController()
		{
			this.context = new CarNotesContext();
		}

        public User FindUserByUsername(String username)
        {
            User user = context.Users.FirstOrDefault(n => n.Username == username);
            return user;
        }

        public bool CheckUsernameAvailability(String username)
        {
            List<User> users = GetUsers();

            bool result = true;

            foreach (User u in users)
            {
                if (u.Username == username)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void AddCar(Car car, int userId)
        {
            car.OwnerId = userId;
            context.Cars.Add(car);
            context.SaveChanges();
        }
        public void AddNote(Note note, int carId)
        {
            note.CarId = carId;
            context.Notes.Add(note);
            context.SaveChanges();
        }
        public List<Car> FindUserCars(int userId)
        {
            var allCars = context.Cars.ToList();
            List<Car> userCars = new List<Car>();
            foreach (Car car in allCars)
            {
                if (car.OwnerId == userId)
                    userCars.Add(car);
            }
            return userCars;
        }
        public List<Note> FindCarNotes(int carId)
        {
            var allNotes = context.Notes.ToList();
            List<Note> carNotes = new List<Note>();
            foreach (Note note in allNotes)
                if (note.CarId == carId)
                    carNotes.Add(note);
            return carNotes;
        }

        public void DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            var userCars = FindUserCars(user.Id);
            foreach (Car car in userCars)
            {
                var carNotes = FindCarNotes(car.Id);
                foreach (Note note in carNotes)
                {
                    context.Notes.Remove(note);
                }
                context.Cars.Remove(car);

            }
            context.Users.Remove(user);
            context.SaveChanges();

        }

        public void DeleteCar(int id)
        {
            var car = context.Cars.Find(id);
            var carNotes = FindCarNotes(car.Id);

            foreach (Note note in carNotes)
                context.Notes.Remove(note);

            context.Cars.Remove(car);

            context.SaveChanges();
        }

        public void deleteNote(int id)
        {
            var note = context.Notes.Find(id);

            context.Notes.Remove(note);

            context.SaveChanges();
        }

	}
}
