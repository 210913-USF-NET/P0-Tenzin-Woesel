using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snow Lion Store");
            
            new MainMenu().Start();
            

        }

        
    }
}
