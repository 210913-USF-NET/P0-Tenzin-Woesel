using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DL;
using Models;
using StoreBL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snow Lion Store");

            RAMCustomerRepo repo = RAMCustomerRepo.GetInstance();
            new MainMenu(new BL(repo)).Start();
            

        }

        
    }
}
