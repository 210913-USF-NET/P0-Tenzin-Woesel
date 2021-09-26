using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Text.RegularExpressions;

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

        public List<Customer> SearchCustomer(string quertStr)
        {
            return _repo.SearchCustomer(quertStr);
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetAllStores();
        }

        public List<LineItems> GetLineItems()
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(string email)
        {
            _repo.DeleteCustomer(email);
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            return _repo.UpdateProduct(productToUpdate);
        }

        public StoreFront SelectStore(int id)
        {
            return _repo.SelectStore(id);
        }

        public StoreFront AddStore(StoreFront storeFront)
        {
            return _repo.AddStore(storeFront);
        }
    }
}
