namespace Models
{
    public class Product
    {
        public Product() { }
        
        public Product(string name, decimal price, string description, string category)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Category = category;

        }
        /*
            The Product model is supposed to hold the data concerning a customer.
                Properties:
                    • Name
                    • Price
                    • Desc. (optional)
                    • Category (optional)
        */
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public string Description { get; set; }
        
        public string Category { get; set; }

        public override string ToString()
        {
            return $"Product Id: {this.Id}\nProduct Name: {this.Name}\nProduct Price: {this.Price}\nProduct Description: {this.Description}\n";
        }
    }
}