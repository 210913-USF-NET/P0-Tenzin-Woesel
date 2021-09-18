using System.Collections.Generic;
using System.Net.Security;

namespace Models
{
    public class Order
    {
        public Order(){}
        public Order(decimal total)
        {
            this.Total = total;

        }
        /*
            The orders contain information about customer orders.
                Properties:
                    • Order Line Items
                    • Location (that the order was placed)
                    • Total price
        */
        public List<LineItems> LineItems { get; set; }
        
        public decimal Total { get; set; }

        public override string ToString()
        {
            return $"Total Price: {this.Total}\n LineItems: {this.LineItems}";
        }
    }
}