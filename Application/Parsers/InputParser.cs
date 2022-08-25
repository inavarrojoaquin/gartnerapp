using Domain.DTO;

namespace Application.Parsers
{
    /// <summary>
    /// This class could be a class implementing a 
    /// Command Pattern managing the inputs
    /// </summary>
    public class InputParser : IInputParser
    {
        private string[] args;

        public InputParser(string[] args)
        {
            if (args == null)
                throw new ArgumentException("Error: args is null");

            if (args.Length == 0)
                throw new ArgumentException("Error: args are empty");

            if (args.Length != 3)
                throw new ArgumentException(string.Format("Error: args size must be 3. Current size: {0}", args.Length));

            this.args = args;
        }

        public ConsoleInputDTO Parse()
        {
            return new ConsoleInputDTO
            {
                Command = args[0].ToLower(),
                Provider = args[1].ToLower(),
                Path = args[2].ToLower()
            };
        }
    }
}