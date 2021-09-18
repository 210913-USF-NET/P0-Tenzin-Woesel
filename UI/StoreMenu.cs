using System;

namespace UI
{
    public class StoreMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            string userInput = "";
            do
            {
                Console.WriteLine("These are store items.");
                //Show the lists of items and then show the options of adding to cart
                Console.WriteLine("[1] Show product details.");
                Console.WriteLine("[2] Add item to Cart.");
                Console.WriteLine("[x] Back to Main Menu.");

                switch (userInput)
                {
                    case "1":
                        ProductDetails();
                        break;
                    case "x":
                        Console.WriteLine("Go back");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }


            } while (!exit);
        }

        private void ProductDetails()
        {
            //Bring in the details of the product chosen
        }
    }
}