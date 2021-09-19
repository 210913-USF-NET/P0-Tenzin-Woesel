using System;
using System.Linq;
using System.Collections.Generic;
using StoreBL;
using DL;
using Models;

namespace UI
{
    public class MainMenu : IMenu
    {
        // private IBL _bl;
        // public MainMenu(IBL bl)
        // {
        //     _bl = bl;
        // }
        public void Start()
        {
            Console.WriteLine("This is the Main Menu");
            bool exit = false;
            string userInput = "";
            do
            {
                Console.WriteLine("[0] Returning customer");
                Console.WriteLine("[1] New Customer");
                Console.WriteLine("[2] Window Shop");
                Console.WriteLine("[x] Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        CurrentCustomer();
                        break;
                    case "1":
                        new NewUserMenu(new BL(RAMCustomerRepo.GetInstance())).Start();
                        break;
                    case "2":
                        JustBrowse();
                        break;
                    case "x":
                        Console.WriteLine("Exit program.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ivalid input.");
                        break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Sign into the account with user credentials
        /// </summary>
        private void CurrentCustomer()
        {
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();

            //Get the lists of customers from the DB and check if this Name is available
            List<String> customerNames = new List<string> { "tenzin", "woesel" };

            if (customerNames.Contains(userName))
            {
                // then show the list of items and let them add items to cart
            }
        }
        private void JustBrowse()
        {
            //if user choses this then get the List<Items> and display to user
        }


    }
}