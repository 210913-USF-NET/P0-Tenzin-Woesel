namespace Models
{
    public class Inventory
    {
        public Inventory() { }

        public Inventory(int Id, int Quantity)
        {
            this.Id = Id;
            this.Quantity = Quantity;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Inventory Id : {this.Id}\n Quantity: {this.Quantity}";
        }
    }
}