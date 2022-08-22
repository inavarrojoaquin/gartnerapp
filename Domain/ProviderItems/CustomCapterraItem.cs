namespace Domain.ProviderItems
{
    public class CustomCapterraItem : ICustomItem
    {
        public string Name { get; internal set; }
        public List<string> Tags { get; internal set; } = new List<string>();
        public string Twitter { get; internal set; }
    }
}