using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface ICustomerRepo
    {
        Customer AddCustomer();

        List<Customer> GetAllCustomers();

        void DeleteCustomer();

        void UpdateCustomer();
    }
}
