using System;
using System.Collections.Generic;
using StoreBL;
using Models;
using Serilog;

namespace UI
{
    public class NewUserMenu : IMenu
    {
        private IBL _bl;
        public NewUserMenu(IBL bl)
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
                Console.WriteLine("[1] Create Account");
                Console.WriteLine("[2] Cancel");
                Console.WriteLine("[x] Go to Main Menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateUser();
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

        private void CreateUser()
        {
            JustBorder();
            Console.WriteLine("Creating User\n");
            Customer cust = new Customer();

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            //if name is already in DB then promt user to give another name
            cust.Name = name;

            Console.WriteLine("\nEnter Address: ");
            string address = Console.ReadLine();
            cust.Address = address;

        inputEmail:
            Console.WriteLine("\nEnter Email Address :");
            string email = Console.ReadLine();
            cust.Email = email;
            try
            {
                cust.Email = email;
            }
            catch (InputInvalidException e)
            {
                Console.WriteLine(e.Message);
                goto inputEmail;
            }

            Customer addedCustomer = _bl.AddCustomer(cust);
            JustBorder();
            Console.WriteLine($"\nYou created {addedCustomer}");
            Log.Information("Customer created");
            JustBorder();

            MenuFactory.GetMenu("current user").Start();
        }
        private void GetACustomer()
        {

        }

        private void JustBorder()
        {
            Console.WriteLine("==========================\n");
        }
    }
}