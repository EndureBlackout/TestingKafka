namespace MessageAPI.Models
{
    public class Order
    {
        public string Id { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}
