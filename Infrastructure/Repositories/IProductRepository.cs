using Domain.ProviderItems;

namespace Infrastructure.Repositories
{
    public interface IProductRepository
    {
        void Insert(IProduct item);
    }
}
