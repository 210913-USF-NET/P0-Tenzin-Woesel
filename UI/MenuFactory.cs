using System;
using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {


        public static IMenu GetMenu(string menuString)
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<P0TenzinStoreContext> option = new DbContextOptionsBuilder<P0TenzinStoreContext>().UseSqlServer(connectionString).Options;
            P0TenzinStoreContext context = new P0TenzinStoreContext(option);
            switch (menuString.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "current user":
                    return new CurrentUserMenu(new BL(new DBCustomerRepo(context)));
                case "new user":
                    return new NewUserMenu(new BL(new DBCustomerRepo(context)));
                case "order menu":
                    return new OrderMenu(new BL(new DBCustomerRepo(context)));
                default:
                    return null;
            }
        }
    }
}