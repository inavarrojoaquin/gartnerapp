using Domain.ProviderItems;

namespace Application.Providers
{
    public interface IProviderImporter
    {
        ICollection<IProduct> GetItems();
        string Generate(ICollection<IProduct> items);
        void Insert(ICollection<IProduct> items);
    }
}
