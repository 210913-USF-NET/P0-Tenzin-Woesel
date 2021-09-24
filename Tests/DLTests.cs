using System.Collections.Generic;
using System.Linq;
using DL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Entity = DL.Entities;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<Entity.P0TenzinStoreContext> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<Entity.P0TenzinStoreContext>().UseSqlite("Filename= Test.db").Options;
            Seed();
        }

        //Testing Read operation
        [Fact]
        public void GetAllCustomersShouldGetAllCustomer()
        {
            using(var context = new Entity.P0TenzinStoreContext(options))
            {
                //ARRANGE
                ICustomerRepo repo = new DBCustomerRepo(context);

                //ACT
                var customers = repo.GetAllCustomers();

                //ASSERT
                Assert.Equal(1, customers.Count);
            }
        }
        [Fact]
        public void AddingCustomerShouldAddACustomer()
        {
            using (var context = new Entity.P0TenzinStoreContext(options))
            {
                ICustomerRepo repo = new DBCustomerRepo(context);

                Models.Customer custToAdd = new Models.Customer()
                {
                    Id = 1,
                    Name = "Tenzin",
                    Address = "234 City",
                    Email = "hr@net.com"
                };

                repo.AddCustomer(custToAdd);
            }

            using (var context = new Entity.P0TenzinStoreContext(options))
            {
                //ASSERT
                Entity.Customer custo = context.Customers.FirstOrDefault(c => c.Id ==1);

                Assert.NotNull(custo);
                Assert.Equal(custo.Name, "Tenzin");
                Assert.Equal(custo.Address, "234 City");
            }


        }

        private void Seed()
        {
            using(var context = new Entity.P0TenzinStoreContext(options))
            {
                //first we are going to make sure the DB is in clean state
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Customers.AddRange(new Entity.Customer(){
                    Id = 1,
                    Name = "Tenzin",
                    Address = "234 City",
                    Email = "hr@net.com"
                });

                context.SaveChanges();
            }
        }
    }
}