using Application.Generators;
using Domain.Common;

namespace Application.Providers
{
    public class ProviderFactory : IProviderFactory
    {
        public IProvider ProductParse(string targetProvider,
                                      string path,
                                      IPathGenerator pathGenerator)
        {
            if (targetProvider == Constants.CAPTERRA)
                return new CapterraProvider(path, pathGenerator);

            if (targetProvider == Constants.SOFTWAREADVICE)
                return new SoftwareAdviceProvider(path, pathGenerator);

            return new ThirdProvider();
        }
    }
}