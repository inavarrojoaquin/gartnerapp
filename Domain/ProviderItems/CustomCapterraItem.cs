namespace Domain.ProviderItems
{
    public class CapterraProduct : IProduct
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Twitter { get; set; }
    }
}