using System;
using System.Collections.Generic;
using StoreBL;
using Models;

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
                        Console.WriteLine("Exit program.");
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
            Console.WriteLine("Creating User");

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            //if name is already in DB then promt user to give another name
            Console.WriteLine("Enter Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Email Adress :");
            string email = Console.ReadLine();

            List<Order> orders = new List<Order>();
            Order order = new Order(1.23M);
            order.LineItems = new List<LineItems>();
            orders.Add(order);
            Customer customer = new Customer(name, address, email);
            customer.Order = orders;
            foreach (var item in orders)
            {
                Console.WriteLine("We are here");
                Console.WriteLine("Order is " + item.ToString());
            }
            _bl.AddCustomer(customer);

            Console.WriteLine(customer);
        }
    }
}