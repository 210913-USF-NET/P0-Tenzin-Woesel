using System;
using System.Collections.Generic;
using StoreBL;
using Models;

namespace UI
{
    public class AdminMenu : IMenu
    {
        private IBL _bl;

        public AdminMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Console.WriteLine("Welcome big boss!!!");
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("[1] View all users.");
                Console.WriteLine("[2] View All Store.");
                Console.WriteLine("[3] View Inventory");
                Console.WriteLine("[x] Back to Main menu." );
                input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        GetAllCustomers();
                        break;
                    case "2":
                        break;
                    case "3":
                        GetAllProducts();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            } while (!exit);
        }

        private void GetAllCustomers()
        {
            List<Customer> customers = _bl.GetAllCustomers();
            foreach (Customer cust in customers)
            {
                Console.WriteLine(cust);
                Console.WriteLine();
            }
        }

        private void GetAllProducts()
        {
            List<Product> products = _bl.GetAllProducts();
            foreach (Product product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }
        }
    }
}