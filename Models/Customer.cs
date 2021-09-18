using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Customer(){}

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
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public List<Order> Order { get; set; }

        public override string ToString()
        {
            return $"Customer Name: {this.Name} \nAddress: {this.Address} \n Email:{this.Email} \n Order: {this.Order}";
        }
    }
}
