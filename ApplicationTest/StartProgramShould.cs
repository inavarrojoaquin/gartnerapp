using Application;
using Application.Providers;
using NSubstitute;

namespace ApplicationTest
{
    public class StartProgramShould
    {
        private StartProgram startProgram;
        private IProviderFactory providerFactory;
        //private IDatabaseFactorySectionHandler databaseFactorySectionHandler;

        [SetUp]
        public void SetUp()
        {
            providerFactory = Substitute.For<IProviderFactory>();
            //databaseFactorySectionHandler = Substitute.For<IDatabaseFactorySectionHandler>();
        }

        [Test]
        public void InitializedAsExpected()
        {
            string[] args = { "Arg1", "Arg2", "Arg3" };

            providerFactory.Execute(Arg.Any<string>()).Returns(new CapterraProvider());

            startProgram = new StartProgram(args,
                                            providerFactory);
        }

        [Test]
        public void RaiseExWhenArgsAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => startProgram = new StartProgram(null, null));
        }

        [Test]
        public void RaiseExWhenArgsAreEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => startProgram = new StartProgram(new string[0], null));

            Assert.IsTrue(ex.Message.Contains("Error: Arguments are empty"));
        }

        [Test]
        public void RaiseExWhenCommandImportAndArgsAreDefferentFrom3()
        {
            string[] args = { "Import" };
            
            startProgram = new StartProgram(args, null);

            var ex = Assert.Throws<ArgumentException>(() => startProgram.Run());

            Assert.IsTrue(ex.Message.Contains(string.Format("Error: Arguments size must be 3. Current size: {0}",
                                                    args.Length)));
        }
    }
}