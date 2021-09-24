using System;
using System.Collections.Generic;
using StoreBL;
using Models;

namespace UI
{
    public class CurrentUserMenu : IMenu
    {
        private IBL _bl;

        public CurrentUserMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Console.WriteLine("Welcome to SLS");
            bool exit = false;
            string userInput = "";
            do
            {
                Console.WriteLine("[1] Log In");
                Console.WriteLine("[2] Cancel");
                Console.WriteLine("[x] Go to Main Menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ValidateUser();
                        break;
                    case "2":
                        exit = true;
                        break;
                    case "x":
                        Console.WriteLine("Go to main menu.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ivalid input.");
                        break;
                }
            } while (!exit);
        }

        private void ValidateUser()
        {
            Console.WriteLine("Enter your name");
            string cName = Console.ReadLine();
            List<Customer> allCustomers = _bl.SearchCustomer(cName);

            if(allCustomers == null || allCustomers.Count == 0)
            {
                Console.WriteLine("No such users :/");
                return;
            }
            
            Console.WriteLine("Welcome to your profile." + cName);
            MenuFactory.GetMenu("current user").Start();
        }
    }
}