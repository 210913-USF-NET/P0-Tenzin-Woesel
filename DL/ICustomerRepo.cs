using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface ICustomerRepo
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(string email);

        List<Customer> GetAllCustomers();

        void DeleteCustomer(string email);

        Customer UpdateCustomer(Customer customerToUpdate);

        Customer AddAnOrder(Order order);

        List<Customer> SearchCustomer(string queryStr);

        List<Product> GetAllProducts();
    }
}
