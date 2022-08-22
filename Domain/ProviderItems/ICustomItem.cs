namespace Domain.ProviderItems
{
    public interface ICustomItem
    {
        string Name { get; }
        List<string> Tags { get; }
        string Twitter { get; }
    }
}