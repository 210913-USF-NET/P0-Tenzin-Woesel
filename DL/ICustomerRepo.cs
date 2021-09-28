using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface ICustomerRepo
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(string name);
        Order AddAnOrder(Order order);
        Product AddProduct(Product product);
        StoreFront AddStore(StoreFront storeFront);
        LineItems AddLineItem(LineItems lineItems);

        Inventory AddInventory(Inventory inventory);
        List<Customer> GetAllCustomers();
        List<Product> GetAllProducts();

        Product GetProductById(int productId);
        List<Order> GetAllOrders();
        List<LineItems> GetLineItems();
        List<StoreFront> GetAllStores();
        List<Inventory> GettAllInventories();
        void DeleteCustomer(string email);
        Customer UpdateCustomer(Customer customerToUpdate);
        Product UpdateProduct(Product productToUpdate);

        Order UpdateOrder(Order orderToUpdate);
        List<Customer> SearchCustomer(string queryStr);

        Inventory UpdateInventory(Inventory inventoryToUpdate);
        StoreFront SelectStore(int id);

        List<Inventory> GetInventoriesByStoreId(int storeId);

        // List<LineItems> AddLineItems(List<LineItems> lineItems);
    }
}
