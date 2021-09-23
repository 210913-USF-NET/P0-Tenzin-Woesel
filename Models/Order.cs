using System.Collections.Generic;
using System.Net.Security;

namespace Models
{
    public class Order
    {
        // public Order(){}
        public Order(decimal total) : this()
        {
            this.Total = total;
        }

        public Order()
        {
            this.LineItems = new List<LineItems>();
        }
        /*
            The orders contain information about customer orders.
                Properties:
                    • Order Line Items
                    • Location (that the order was placed)
                    • Total price
        */
        public int Id { get; set; }
        public List<LineItems> LineItems { get; set; }
        
        public decimal Total { get; set; }

        public override string ToString()
        {
            return $"Total Price: {this.Total}\n LineItems: {this.LineItems}";
        }
    }
}