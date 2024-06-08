namespace BillManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string PONumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HSN { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
    }
}
