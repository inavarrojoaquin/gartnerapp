﻿using Application.Generators;
using Application.Providers;

namespace ApplicationTest.Providers
{
    public class ProviderFactoryShould
    {
        private ProviderFactory providerFactory;
        private PathGenerator pathGenerator;

        [SetUp]
        public void SetUp()
        {
            providerFactory = new ProviderFactory();
            pathGenerator = new PathGenerator();
        }
        [Test]

        public void CreateCapterraProviderAsExpected()
        {
            IProvider targetProvider = providerFactory.ProductParse(TestConstants.CAPTERRA, "path", pathGenerator);

            Assert.That(targetProvider.GetType(), Is.EqualTo(typeof(CapterraProvider)));

            //Assert.DoesNotThrow(() => targetProvider.Run(TestConstants.CAPTERRA_FILE_PATH));
        }

        [Test]
        public void CreateSoftwareAdvideProviderAsExpected()
        {
            IProvider targetProvider = providerFactory.ProductParse(TestConstants.SOFTWAREADVICE, "path", pathGenerator);

            Assert.That(targetProvider.GetType(), Is.EqualTo(typeof(SoftwareAdviceProvider)));

            //Assert.DoesNotThrow(() => targetProvider.Run(TestConstants.SOFTWAREADVICE_FILE_PATH));
        }

        [Test]
        public void CreateThirdProviderAsExpected()
        {
            IProvider targetProvider = providerFactory.ProductParse("thirdProvider",
                                                                    "path",
                                                                    pathGenerator);

            Assert.That(targetProvider.GetType(), Is.EqualTo(typeof(ThirdProvider)));
        }
    }
}
