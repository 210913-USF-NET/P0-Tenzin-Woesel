﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Customer
    {
        public Customer()
        {
        }

        // public Customer(string pinNum)
        // {
        //     this.PinNum = pinNum;
        // }

        public Customer(string name, string address, string email)
        {
            this.Name = name;
            this.Address = address;
            this.Email = email;

        }
        /*
            The customer model is supposed to hold the data concerning a customer.
                Properties:
                    • Name
                    • Address
                    • Email/Phone number
                    • List of Orders
        */
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        // public string PinNum { get; }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {

                if (value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Email address should not be empty");
                    Log.Warning(e.Message);
                    throw e;

                }
                else
                {
                    _email = value;
                }
            }
        }

        public List<Order> Order { get; set; }

        public override string ToString()
        {
            return $"Customer ID: {this.Id}\nCustomer Name: {this.Name} \nAddress: {this.Address} \nEmail:{this.Email} \n";
        }
    }
}
