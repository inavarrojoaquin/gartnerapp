using Domain.ProviderItems;

namespace Domain.Providers
{
    public interface IProviderProduct
    {
        ICollection<IProduct> Products { get; }
    }
}