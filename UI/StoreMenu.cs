using System;
using System.Runtime.CompilerServices;
using Models;
using System.Collections.Generic;
using StoreBL;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.Data.SqlClient.Server;

namespace UI
{
    public class StoreMenu : IMenu
    {
        private IBL _bl;

        private StoreService _storeService;

        public StoreMenu(IBL bl, StoreService storeService)
        {
            _bl = bl;
            _storeService = storeService;
        }
        public void Start()
        {
            bool exit = false;
            string userInput = "";
            do
            {
                Console.WriteLine("****** Snow Lion Stores ******");
                //Show the lists of items and then show the options of adding to cart
                Console.WriteLine("[1] View Items");
                Console.WriteLine("[2] Select Another Location");
                Console.WriteLine("[3] Get inventories.");
                Console.WriteLine("[x] Back to Main Menu.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewItems();
                        break;
                    case "2":
                        SelectAnotherLocation();
                        MenuFactory.GetMenu("store").Start();
                        break;
                    case "5":
                        SelectAnItem();

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

        private void ViewItems()
        {
            int storeId = StaticService.currentStore.Id;
            List<Inventory> inventories = _bl.GetInventoriesByStoreId(storeId);



            List<Product> allProducts = _bl.GetAllProducts();
            selectAnItem:
            var tempInventory = from inv in inventories
                                join prods in allProducts on inv.ProductID equals prods.Id
                                select new { inv.ProductID, prods.Name, inv.Quantity, prods.Price, prods.Description };

            foreach (var inv in tempInventory)
            {
                Console.WriteLine($"{inv.ProductID}");
                Console.WriteLine("\nItem Name : " + inv.Name);
                Console.WriteLine("Description : " + inv.Description);
                Console.WriteLine($"Items left : {inv.Quantity}\n");
            }

        }

        private void AddItemsToOrder()
        {
            int storeId = StaticService.currentStore.Id;
            int customerId = StaticService.currentCustomer.Id;

            Order newOrder = new Order();
            newOrder.CustomerId = customerId;
            newOrder.StoreFrontId = storeId;

            newOrder = _bl.AddOrder(newOrder);

            LineItems items = new LineItems();
            items.OrderId = newOrder.CustomerId;
        }

        private void SelectAnotherLocation()
        {
            List<StoreFront> allStores = _bl.GetAllStores();
            if (allStores == null || allStores.Count == 0)
            {
                Console.WriteLine("Stores under constructions.");
                return;
            }

            StoreFront selectedStore = _storeService.SelectAStore("Pick a store to shop at", allStores);

            Console.WriteLine("You Selected " + selectedStore);

            StaticService.currentStore = selectedStore;
        }

        private void  SelectAnItem()
        {   

            int storeId = StaticService.currentStore.Id;
            List<Inventory> inventories = _bl.GetInventoriesByStoreId(storeId);

            Inventory selectedItem = _storeService.SelectAnItem("Pick an item to add to order : ", inventories);

            Console.WriteLine("You selected " + selectedItem);

            int customerId = StaticService.currentCustomer.Id;

            Console.WriteLine(customerId);

            Order newOrder = new Order();
            newOrder.CustomerId = customerId;
            newOrder.StoreFrontId = storeId;

            newOrder = _bl.AddOrder(newOrder);

            LineItems items = new LineItems();

            items.ProductId = selectedItem.ProductID;

            items.OrderId = newOrder.Id;

            Console.WriteLine("How many do you want to add?");
            items.Quantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine(items.Quantity);


            Console.WriteLine("Do you want to add more items? ");
            // if yes
            //  then send it back to the 
            //  #region if no then place the order
                  
            //  #endregion
            //Update here afterwards
            // _bl.AddOrder(newOrder);


        }
    }
}