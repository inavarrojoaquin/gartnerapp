using Domain.DTOs;
using Domain.ProviderItems;

namespace Domain.Providers
{
    public class Capterra : IProviderProduct
    {
        public ICollection<IProduct> Products { get; }

        public Capterra(ICollection<CapterraProductDTO> products)
        {
            Products = new List<IProduct>();

            foreach (var item in products)
            {
                CapterraProduct customItem = new CapterraProduct();
                customItem.Name = item.Name;
                customItem.Tags.Add(item.Tags);
                customItem.Twitter = item.Twitter;

                Products.Add(customItem);
            }
        }
    }
}