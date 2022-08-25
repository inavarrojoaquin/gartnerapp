using Application.Generators;
using Domain.DTOs;
using Domain.ProviderItems;
using Domain.Providers;
using YamlDotNet.Serialization.NamingConventions;

namespace Application.Providers
{
    public class CapterraProvider : IProvider
    {
        private readonly string inputPath;
        private readonly IPathGenerator pathGenerator;

        public CapterraProvider(string inputPath,
                                IPathGenerator pathGenerator)
        {
            this.inputPath = inputPath;
            this.pathGenerator = pathGenerator;
        }

        public ICollection<IProduct> GetItems()
        {
            ICollection<IProduct> products = new List<IProduct>();
            string targetPath = pathGenerator.Generate(inputPath);

            using (var input = File.OpenText(targetPath))
            {
                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                    .Build();

                var items = deserializer.Deserialize<ICollection<CapterraProductDTO>>(input);
                
                products = new Capterra(items).Products;
            }

            return products;
        }
    }
}