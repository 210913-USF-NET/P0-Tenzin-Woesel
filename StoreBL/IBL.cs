using System.Collections.Generic;
using System.Net.Security;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customerToUpdate);

        void DeleteCustomer(string email);
        List<Customer> SearchCustomer(string quertStr);

        List<Product> GetAllProducts();

        List<Order> GetAllOrders();

        List<StoreFront> GetAllStores();

        StoreFront SelectStore(int id);

        StoreFront AddStore(StoreFront storeFront);

        List<LineItems> GetLineItems();
        Product UpdateProduct(Product productToUpdate);



    }
}