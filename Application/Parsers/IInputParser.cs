using Domain.DTO;

namespace Application.Parsers
{
    public interface IInputParser
    {
        ConsoleInputDTO Parse();
    }
}
