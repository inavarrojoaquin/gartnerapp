using Application;
using Application.Generators;
using Application.Parsers;
using Application.Providers;
using Application.Repositories;
using Domain.DTO;
using Domain.ProviderItems;
using NSubstitute;

namespace ApplicationTest
{
    public class StartProgramShould
    {
        private StartProgram startProgram;
        //private IProviderFactory providerFactory;
        //private IDatabaseFactorySectionHandler databaseFactorySectionHandler;

        [SetUp]
        public void SetUp()
        {
            //databaseFactorySectionHandler = Substitute.For<IDatabaseFactorySectionHandler>();
        }

        [Test]
        public void RunAsExpected()
        {
            const string argProvider = "Provider";
            const string argPath = "path";

            IInputParser inputParser = Substitute.For<IInputParser>();
            inputParser.Parse()
                       .Returns(new ConsoleInputDTO
                       {
                           Provider = argProvider,
                           Path = argPath
                       });
            
            IProviderFactory providerFactory = Substitute.For<IProviderFactory>();
            IProvider provider = Substitute.For<IProvider>();
            
            ICollection<IProduct> items = new List<IProduct>();
            items.Add(new CapterraProduct());
            items.Add(new CapterraProduct());

            provider.GetItems().Returns(items);
            providerFactory.ProductParse(argProvider,
                                         argPath,
                                         Arg.Any<IPathGenerator>())
                           .Returns(provider);

            IReportConsoleGenerator reportConsoleGenerator = Substitute.For<IReportConsoleGenerator>();
            
            int generatorCounter = 0;
            reportConsoleGenerator
                .When(x => x.Generate(Arg.Is(items)))
                .Do(y => generatorCounter++);
            
            IRepository repository = Substitute.For<IRepository>();

            int repositoryCounter = 0;
            repository.When(x => x.Insert(Arg.Any<IProduct>()))
                      .Do(y => repositoryCounter++);

            startProgram = new StartProgram(inputParser,
                                            providerFactory,
                                            reportConsoleGenerator,
                                            repository);
            startProgram.Run();

            inputParser.Received(1).Parse();
            providerFactory.Received(1).ProductParse(argProvider,
                                                     argPath,
                                                     Arg.Any<IPathGenerator>());
            reportConsoleGenerator.Received(1).Generate(Arg.Is(items));
            repository.Received(2).Insert(Arg.Any<IProduct>());

            Assert.That(generatorCounter, Is.EqualTo(1));
            Assert.That(repositoryCounter, Is.EqualTo(2));
        }

    }
}