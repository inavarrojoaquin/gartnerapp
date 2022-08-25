using Domain.ProviderItems;

namespace Application.Generators
{
    public interface IReportConsoleGenerator
    {
        string Generate(ICollection<IProduct> items);
    }
}
