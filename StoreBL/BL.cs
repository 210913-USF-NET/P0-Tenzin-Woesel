using System;
using System.Collections.Generic;
using Models;
using DL;

namespace StoreBL
{
    public class BL : IBL

    {
        
        private ICustomerRepo _repo;

        public BL(ICustomerRepo repo)
        {
            _repo = repo;
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer AddCustomer(Customer customer)
        {
            return _repo.AddCustomer(customer);
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            return _repo.UpdateCustomer(customerToUpdate);
        }
    }
}
