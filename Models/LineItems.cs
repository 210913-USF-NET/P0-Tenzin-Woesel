namespace Models
{
    public class LineItems
    {
        /*
            The line items contain information about a particular product and its quantity.
                Properties:
                    • Product
                    • Quantity
        */

        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}