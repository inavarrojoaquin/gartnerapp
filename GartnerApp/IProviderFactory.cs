namespace GartnerApp
{
    public interface IProviderFactory
    {
        IProvider Execute(string targetProvider);
    }
}