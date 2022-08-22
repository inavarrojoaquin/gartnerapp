using Domain.DTOs;
using Domain.ProviderItems;

namespace Domain.Providers
{
    public class Capterra : ICustomProvider
    {
        public List<ICustomItem> Products { get; }

        public Capterra(List<CapterraItemDTO> capterraList)
        {
            Products = new List<ICustomItem>();

            foreach (var item in capterraList)
            {
                CustomCapterraItem customItem = new CustomCapterraItem();
                customItem.Name = item.Name;
                customItem.Tags.Add(item.Tags);
                customItem.Twitter = item.Twitter;

                Products.Add(customItem);
            }
        }
    }
}