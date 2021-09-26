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
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public Product Product { get; set; }

    }
}