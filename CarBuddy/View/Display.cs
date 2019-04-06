using System;
using System.Collections.Generic;
using System.Text;

namespace CarBuddy.View
{
    class Display
    {
        Buisness.UserController controller = new Buisness.UserController();

        private void showIntialMenu()
        {
            Console.WriteLine("Greetings! Do you have an account?(Y/N)\n");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.WriteLine("Nice! What is your username: \n");
                string username = Console.ReadLine();
                controller.currentUser = controller.FindUserByUsername(username);
            }
            else if (answer == "N")
            {

                Console.WriteLine("Nice! You should create one. What username do you want?: \n");

                Data.Models.User user = new Data.Models.User();
                string username = Console.ReadLine();
                user.Username = username;

            }
        }
    }
}
