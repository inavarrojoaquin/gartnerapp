using Domain.ProviderItems;

namespace Application.Providers
{
    public class ThirdProvider : IProvider
    {
        public ICollection<IProduct> GetItems()
        {
            return new List<IProduct>();
        }
    }
}