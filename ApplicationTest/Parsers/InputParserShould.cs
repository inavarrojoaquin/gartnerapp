using Application.Parsers;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Parsers
{
    public class InputParserShould
    {
        private InputParser inputParser;

        [Test]
        public void GetExpectedInput()
        {
            string[] args = new string[] { "Arg1", "Arg2", "Arg2" };
            inputParser = new InputParser(args);
            ConsoleInputDTO consoleInputDTO = inputParser.Parse();

            Assert.That(consoleInputDTO.Command, Is.EqualTo(args[0].ToLower()));
            Assert.That(consoleInputDTO.Provider, Is.EqualTo(args[1].ToLower()));
            Assert.That(consoleInputDTO.Path, Is.EqualTo(args[2].ToLower()));
        }

        [Test]
        public void RaiseExWhenArgsAreNull()
        {
            var ex = Assert.Throws<ArgumentException>(() => inputParser = new InputParser(null));

            Assert.That(
                ex.Message.Contains("Error: args is null"),
                Is.True);
        }

        [Test]
        public void RaiseExWhenArgsAreEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => inputParser = new InputParser(new string[0]));

            Assert.That(ex.Message.Contains("Error: args are empty"),
                        Is.True);
        }

        [Test]
        public void RaiseExWhenCommandImportAndArgsAreDefferentFrom3()
        {
            string[] args = { "Import" };

            var ex = Assert.Throws<ArgumentException>(() => inputParser = new InputParser(args));

            Assert.That(ex.Message.Contains(string.Format("Error: args size must be 3. Current size: {0}", args.Length)),
                        Is.True);
        }
    }
}
