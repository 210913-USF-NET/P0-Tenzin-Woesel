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

        void UpdateCustomer(Customer customer);
    }
}
