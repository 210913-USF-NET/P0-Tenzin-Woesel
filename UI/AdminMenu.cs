using System;
using System.Collections.Generic;
using StoreBL;
using Models;
using System.Globalization;

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
                    case "4":
                        SelectAProduct();
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

        private void SelectAProduct()
        {
            productToSelect:
            Console.WriteLine("Select a product to get details.");
            List<Product> allProducts = _bl.GetAllProducts();
            if(allProducts == null || allProducts.Count == 0)
            {
                Console.WriteLine("No products :/");
                return;
            }
            for (int i = 0; i < allProducts.Count; i++)
            {
                Console.WriteLine($"[{i}] {allProducts[i]}");
            }
            
            string input = Console.ReadLine();
            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if(parseSuccess && parsedInput >= 0 && parsedInput < allProducts.Count)
            {
                Product selectedProduct = allProducts[parsedInput];
                Console.WriteLine($"You chose {selectedProduct.Name}");
            }else
            {
                Console.WriteLine("Invalid input");
                goto productToSelect;
            }
            
        }
    }
}