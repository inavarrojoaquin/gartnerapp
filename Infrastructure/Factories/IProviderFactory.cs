using Infrastructure.Providers;

namespace Infrastructure.Factories
{
    public interface IProviderFactory
    {
        IProvider Execute(string targetProvider);
    }
}