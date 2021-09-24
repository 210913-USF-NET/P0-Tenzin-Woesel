using System;
using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using DL.Entities;

namespace DL
{
    public class DBCustomerRepo : ICustomerRepo
    {
        private Entity.P0TenzinStoreContext _context;

        public DBCustomerRepo(Entity.P0TenzinStoreContext context)
        {
            _context = context;
        }
        public Model.Customer AddAnOrder(Model.Order order)
        {
            throw new System.NotImplementedException();
        }

        public Model.Customer AddCustomer(Model.Customer customer)
        {
            Entity.Customer customerToAdd = new Entity.Customer()
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
            Entity.Customer updateCustomer = new Entity.Customer()
            {
                Id = customerToUpdate.Id,
                Name = customerToUpdate.Name,
                Address = customerToUpdate.Address,
                Email = customerToUpdate.Email
            };

            updateCustomer = _context.Customers.Update(updateCustomer).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customer()
            {
                Id = updateCustomer.Id,
                Name = updateCustomer.Name,
                Address = updateCustomer.Address,
                Email = updateCustomer.Email
            };
        }

        public List<Model.Customer> SearchCustomer(string queryStr)
        {
            return _context.Customers.Where(
                custo => custo.Name.Contains(queryStr)).Select(
                    c => new Model.Customer()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Address = c.Address,
                        Email = c.Email
                    }
                ).ToList();
        }
    }
}