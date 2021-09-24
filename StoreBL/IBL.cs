using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customerToUpdate);

        List<Customer> SearchCustomer(string quertStr);

        List<Product> GetAllProducts();
    }
}