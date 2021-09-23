using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;

namespace DL
{
    public class DBCustomerRepo : ICustomerRepo
    {
        private DL.Entities.P0TenzinStoreContext _context;

        public DBCustomerRepo(DL.Entities.P0TenzinStoreContext context)
        {
            _context = context;
        }
        public Model.Customer AddAnOrder(Model.Order order)
        {
            throw new System.NotImplementedException();
        }

        public Model.Customer AddCustomer(Model.Customer customer)
        {
            DL.Entities.Customer customerToAdd = new Entities.Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email
            };

            customerToAdd = _context.Add(customerToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return new Model.Customer
            {
                Id = customerToAdd.Id,
                Name = customerToAdd.Name,
                Address = customerToAdd.Address,
                Email = customerToAdd.Email
            };
        }

        public void DeleteCustomer(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(customer => new Model.Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Email = customer.Email
            }).ToList();
        }

        public Model.Customer GetCustomer(string email)
        {
            throw new System.NotImplementedException();
        }

        public Model.Customer UpdateCustomer(Model.Customer customerToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}