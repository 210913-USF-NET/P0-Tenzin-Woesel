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
            Entity.Customer customerToDelete = new Entity.Customer()
            {
                Email = email
            };

            customerToDelete = _context.Remove(customerToDelete).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
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

        public List<Model.Product> GetAllProducts()
        {
            return _context.Products.Select(product => new Model.Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = (decimal)product.Price,
                Description = product.Description,
                Category = product.Category

            }).ToList();
        }
        public List<Model.StoreFront> GetAllStores()
        {
            return _context.StoreFronts.Select(stores => new Model.StoreFront()
            {
                Id = stores.Id,
                Name = stores.Name,
                Address = stores.Address
            }).ToList();
        }

        public List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(order => new Model.Order()
            {
                Id = order.Id,
                Total = (decimal)order.Total
            }).ToList();
        }

        public List<Model.LineItems> GetLineItems()
        {
            return _context.LineItems.Select(items => new Model.LineItems()
            {
                Id = items.Id,
                Quantity = (decimal)items.Quantity
            }).ToList();
        }

        public Model.Product UpdateProduct(Model.Product productToUpdate)
        {
            Entity.Product updateProduct = new Entity.Product()
            {
                Id = productToUpdate.Id,
                Name = productToUpdate.Name,
                Price = productToUpdate.Price,
                Description = productToUpdate.Description,
                Category = productToUpdate.Category
            };

            updateProduct = _context.Products.Update(updateProduct).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Product()
            {
                Id = updateProduct.Id,
                Name = updateProduct.Name,
                Price = (decimal)updateProduct.Price,
                Description = updateProduct.Description,
                Category = updateProduct.Category
            };
        }

        public Model.StoreFront SelectStore(int id)
        {
            Entity.StoreFront storeById = _context.StoreFronts.Include("LineItems").FirstOrDefault(s => s.Id == id);
            
            return new Model.StoreFront()
            {
                Id = storeById.Id,
                Name = storeById.Name,
                Address = storeById.Address,
                Inventory = storeById.Inventories.Select(i => new Model.Inventory(){
                    Id = i.Id,
                    Quantity = (int)i.Quantity,
                    ProductID =(int) i.ProductId,
                    StoreID = (int)i.StoreId
                }).ToList()
            };
        }

        public Model.StoreFront AddStore(Model.StoreFront storeFront)
        {
            Entity.StoreFront storeToAdd = new Entity.StoreFront()
            {
                Name = storeFront.Name,
                Address = storeFront.Address
            };

            storeToAdd = _context.Add(storeToAdd).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Model.StoreFront()
            {
                Id = storeToAdd.Id,
                Name = storeToAdd.Name,
                Address = storeToAdd.Address
            };
        }
    }
}