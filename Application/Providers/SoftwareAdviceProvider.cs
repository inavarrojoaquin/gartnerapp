using Application.Generators;
using Domain.DTOs;
using Domain.ProviderItems;
using Domain.Providers;
using Newtonsoft.Json;

namespace Application.Providers
{
    public class SoftwareAdviceProvider : IProvider
    {
        private string inputPath;
        private IPathGenerator pathGenerator;

        public SoftwareAdviceProvider(string inputPath, IPathGenerator pathGenerator)
        {
            this.inputPath = inputPath;
            this.pathGenerator = pathGenerator;
        }

        public ICollection<IProduct> GetItems()
        {
            ICollection<IProduct> products = new List<IProduct>();
            string targetPath = pathGenerator.Generate(inputPath);

            string file = File.ReadAllText(targetPath);
            var softwareAdviceDTO = JsonConvert.DeserializeObject<SoftwareAdviceDTO>(file);
            
            products = new SoftwareAdvice(softwareAdviceDTO).Products;

            return products;
        }
    }
}