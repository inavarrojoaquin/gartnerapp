namespace Domain.ProviderItems
{
    public interface IProduct
    {
        string Name { get; set; }
        List<string> Tags { get; set; }
        string Twitter { get; set; }
    }
}