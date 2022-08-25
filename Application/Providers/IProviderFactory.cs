using Application.Generators;

namespace Application.Providers
{
    public interface IProviderFactory
    {
        IProvider ProductParse(string provider, string path, IPathGenerator pathGenerator);
    }
}