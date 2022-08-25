using Domain.ProviderItems;

namespace Application.Providers
{
    public interface IProvider
    {
        ICollection<IProduct> GetItems();
    }
}