using Domain.DTOs;
using Domain.ProviderItems;

namespace Domain.Providers
{
    public class SoftwareAdvice : IProviderProduct
    {
        public ICollection<IProduct> Products { get; }
        public SoftwareAdvice(SoftwareAdviceDTO softwareAdviceDTO)
        {
            Products = new List<IProduct>();

            foreach (var item in softwareAdviceDTO.Products)
            {
                CustomSoftwareAdviceItem customItem = new CustomSoftwareAdviceItem();
                customItem.Name = item.Name;
                customItem.Tags = item.Tags;
                customItem.Twitter = item.Twitter;

                Products.Add(customItem);
            }
        }
    }
}