using System;
using DL;
using StoreBL;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            switch(menuString.ToLower())
            {
                case "main":
                    // return new MainMenu();
                case "new user":
                    return new NewUserMenu(new BL(new CustomerFileRepo()));
                default:
                return null;
            }
        }
    }
}