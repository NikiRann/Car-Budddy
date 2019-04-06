using System;
using System.Collections.Generic;
using System.Text;

namespace CarBuddy.View
{
    class Display
    {
        Buisness.UserController controller = new Buisness.UserController();
        public Display()
        {
            ShowIntialMenu();
        }
        private void ShowIntialMenu()
        {
            Console.Clear();
            Console.WriteLine("Greetings! Do you have an account?(Y/N) ");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.WriteLine("Nice! What is your username:  ");
                string username = Console.ReadLine();
                controller.currentUser = controller.FindUserByUsername(username);
                Garage();
            }
            else if (answer == "N")
            {
                string username;
                Console.WriteLine("Nice! You should create one. ");
                do
                {
                    Console.WriteLine("What username do you want?:  ");
                    username = Console.ReadLine();
                    if (!controller.CheckUsernameAvailability(username))
                    {
                        Console.WriteLine("That one is already taken, choose another one.  ");
                    }
                } while (!controller.CheckUsernameAvailability(username));

                Data.Models.User user = new Data.Models.User();
                user.Username = username;
                Console.WriteLine("What is your first name?:  ");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("What is your last name?:  ");
                user.LastName = Console.ReadLine();

                controller.AddUser(user);
                controller.currentUser = user;

                Garage();

            }
        }
        private void Garage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the garage  ");
            if (controller.FindUserCars(controller.currentUser.Id).Count == 0)
            {
                Console.WriteLine("It looks like you don't have any cars. Add a new one!  ");
                AddCar();
            }
            int step = 1;
            Console.WriteLine($"0. Exit ");
            foreach (Data.Models.Car car in controller.FindUserCars(controller.currentUser.Id))
            {
                Console.WriteLine($"{step}. {car.Model} ");
                step++;
            }
            Console.WriteLine($"{step}. Add Car.  ");
            Console.WriteLine($"{step + 1}. Delete user  ");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
                return;
            if (input == step + 1)
            {
                controller.DeleteUser(controller.currentUser.Id);
                ShowIntialMenu();
            }
            if (input == step)
                AddCar();
            if (input >= 1 && input <= step - 1)
            {

                ShowCarNotes(controller.FindUserCars(controller.currentUser.Id)[input - 1].Id);
            }
        }
        private void ShowCarNotes(int carId)
        {
            Console.Clear();
            List<Data.Models.Note> notes = controller.FindCarNotes(carId);
            int step = 1;
            Console.WriteLine($"0. Back ");
            foreach (Data.Models.Note note in notes)
            {
                Console.WriteLine($"{step}. {note.Name}  ");
                step++;
            }
            Console.WriteLine($"{step}. Add note  ");
            Console.WriteLine($"{step + 1}. Delete car  ");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
                Garage();
            if (input == step)
                AddNote(carId);
            if (input == step + 1)
            {
                Garage();
                controller.DeleteCar(carId);
            }
        }
        private void AddCar()
        {
            Console.Clear();
            Console.WriteLine("What is your car model ?:  ");

            Data.Models.Car car = new Data.Models.Car();

            car.Model = Console.ReadLine();

            controller.AddCar(car, controller.currentUser.Id);

            Garage();
        }
        private void AddNote(int carId)
        {
            Console.Clear();
            Console.WriteLine("What is your note name ?:  ");

            Data.Models.Note note = new Data.Models.Note();

            note.Name = Console.ReadLine();
            Console.WriteLine("Enter some text:  ");
            note.Text = Console.ReadLine(); 

            controller.AddNote(note, carId);

            ShowCarNotes(carId);
        }
    }
}
