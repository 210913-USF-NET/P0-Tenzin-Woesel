using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DL
{
    public sealed class RAMCustomerRepo : ICustomerRepo
    {
        private static RAMCustomerRepo _instance;
        private static List<Customer> _customers;
        private RAMCustomerRepo()
        {
            _customers = new List<Customer>()
            {
                new Customer("1234")
                {
                    Name = "Tenzin",
                    Address = "123",
                    Email = "1234"

                }
            };
        }

        public static RAMCustomerRepo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RAMCustomerRepo();
            }

            return _instance;
        }
        public Customer AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            return customer;
        }
        public Customer GetCustomer(string email)
        {
            foreach (var customer in _customers)
            {
                if (customer.Email.Equals(email))
                {
                    return customer;
                }
            }
            return null;
        }



        public void DeleteCustomer(string email)
        {
            Customer customer = GetCustomer(email);
            if (_customers != null)
            {
                _customers.Remove(customer);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            _customers.Remove(customer);

        }


    }
}