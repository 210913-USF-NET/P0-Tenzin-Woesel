using System;
using System.Runtime.CompilerServices;
using Models;
using System.Collections.Generic;

namespace UI
{
    public class OrderMenu : IMenu
    {
        public void Start()
        {
            bool goBack = false;
            string userInput = "";
            do
            {

                Console.WriteLine("Welcome to this Location");
                Console.WriteLine("These are the items available at this store");
                foreach (var item in ListOfItems())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("[1] Add Item to cart");
                Console.WriteLine("[2] Remove Item from cart.");
                Console.WriteLine("[3] Go Back to Store Menu");
                Console.WriteLine("[x] Go Back to Main Menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        RemoveItem();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }

            } while (!goBack);

        }

        private void AddItem()
        {

        }

        private void RemoveItem()
        {
            
        }

        private List<Product> ListOfItems()
        {
            //Bring in the lists of items from DL
            return new List<Product>();
        }
    }
}