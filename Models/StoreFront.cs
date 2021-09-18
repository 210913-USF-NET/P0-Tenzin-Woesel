using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        public StoreFront(){}
        public StoreFront(string name, string address, string inventory)
        {
            this.Name = name;
            this.Address = address;
            this.Inventory = inventory;

        }
        /*
            The store front contains information pertaining the various store locations.
                Properties:
                    • Name
                    • Address
                    • Inventory
                    • List of Orders

        */

        public string Name { get; set; }
        public string Address { get; set; }
        public string Inventory { get; set; }
        public List<Order> Order { get; set; }

        public override string ToString()
        {
            return $"Store Name: {this.Name} \nAddress: {this.Address} \n Inventory: {this.Inventory} \n Order: {this.Order}";
        }
    }
}