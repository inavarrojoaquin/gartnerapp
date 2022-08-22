using Domain.ProviderItems;

namespace Domain.Providers
{
    public interface ICustomProvider
    {
        List<ICustomItem> Products { get; }
    }
}