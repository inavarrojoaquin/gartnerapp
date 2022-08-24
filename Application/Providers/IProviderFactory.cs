namespace Application.Providers
{
    public interface IProviderFactory
    {
        IProvider Execute(string targetProvider);
    }
}