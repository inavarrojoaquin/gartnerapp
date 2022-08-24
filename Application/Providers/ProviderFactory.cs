using Domain.Common;

namespace Application.Providers
{
    public class ProviderFactory : IProviderFactory
    {
        public IProvider Execute(string targetProvider)
        {
            if (targetProvider == Constants.CAPTERRA)
                return new CapterraProvider();

            if (targetProvider == Constants.SOFTWAREADVICE)
                return new SoftwareAdviceProvider();

            return new ThirdProvider();
        }
    }
}