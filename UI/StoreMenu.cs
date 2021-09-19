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
                Console.WriteLine("****** Snow Lion Stores ******");
                //Show the lists of items and then show the options of adding to cart
                Console.WriteLine("[1] Select a Store");
                Console.WriteLine("[x] Back to Main Menu.");

                switch (userInput)
                {
                    case "1":
                        ListOfStores();
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

        private void ListOfStores()
        {
            //Show the user a list of stores to choose from.
        }
    }
}