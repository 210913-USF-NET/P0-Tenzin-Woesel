using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using DL.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBStoreRepo : IStoreFront
    {
        private Entity.P0TenzinStoreContext _context;

        public DBStoreRepo(Entity.P0TenzinStoreContext context)
        {
            _context = context;
        }
        public Model.StoreFront AddStoreFront(Model.StoreFront storeToAdd)
        {
            Entity.StoreFront addedStore = new Entity.StoreFront()
            {
                Name = storeToAdd.Name,
                Address = storeToAdd.Address,
                Inventories = (ICollection<Entity.Inventory>)storeToAdd.Inventory,
                Orders = (ICollection<Entity.Order>)storeToAdd.Order

            };

            addedStore = _context.Add(addedStore).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.StoreFront
            {
                Id = addedStore.Id,
                Address = addedStore.Address,
                Inventory = (Model.Inventory)addedStore.Inventories,
                Order = (List<Model.Order>)addedStore.Orders
            };
        }

        public void DeleteStoreFront(Model.StoreFront storeToDelete)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.StoreFront> GetAllStoreFronts()
        {
            throw new System.NotImplementedException();
        }

        public Model.StoreFront GetStoreFront(Model.StoreFront store)
        {
            throw new System.NotImplementedException();
        }

        public Model.StoreFront UpdateStoreFront(Model.StoreFront storeToUpdate)
        {
            Entity.StoreFront updatedStore = new Entity.StoreFront()
            {
                Id = storeToUpdate.Id,
                Name = storeToUpdate.Name,
                Address = storeToUpdate.Address,
                // Inventories = storeToUpdate.Inventory.Select(i => new Model.Inventory()
                // {
                //     Id = i.Id,
                //     Quantity = i.Quantity
                // }).ToList(),
                // Inventories = (ICollection<Entity.Inventory>)storeToUpdate.Inventory,
                Orders = (ICollection<Entity.Order>)storeToUpdate.Order
                
            };

            updatedStore = _context.StoreFronts.Update(updatedStore).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return new Model.StoreFront()
            {
                Id = updatedStore.Id,
                Name = updatedStore.Name,
                Address = updatedStore.Address,
                Inventory = (Model.Inventory)updatedStore.Inventories,
                Order = (List<Model.Order>)updatedStore.Orders
            };

        }

        // private List<Inventory> GetInventories()
        // {
        //     return _context.Inventories.Select(invetory => new Model.Inventory()
        //     {
                
        //     })
        // }
    }
}