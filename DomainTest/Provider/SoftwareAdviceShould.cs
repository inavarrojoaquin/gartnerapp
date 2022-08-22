using Domain.DTOs;
using Domain.Providers;

namespace DomainTest.Provider
{
    public class SoftwareAdviceShould
    {
        [Test]
        public void GenerateAsExpected()
        {
            SoftwareAdviceDTO softwareAdviceDTO = new SoftwareAdviceDTO
            {
                Products = new List<SoftwareAdviceItemDTO>
                {
                    new SoftwareAdviceItemDTO
                    {
                        Name = "Name1",
                        Tags = new List<string> { "Tag1", "Tag2" },
                        Twitter = "Twitter1"
                    },
                    new SoftwareAdviceItemDTO
                    {
                        Name = "Name2",
                        Tags = new List<string> { "Tag3", "Tag4" },
                        Twitter = "Twitter2"
                    }
                }
            };

            SoftwareAdvice softwareAdvice = new SoftwareAdvice(softwareAdviceDTO);

            Assert.IsNotNull(softwareAdvice.Products);
            Assert.That(softwareAdvice.Products.Count, Is.EqualTo(2));
            Assert.AreEqual(softwareAdvice.Products.First().Name,
                            softwareAdviceDTO.Products.First().Name);
            Assert.AreEqual(softwareAdvice.Products.First().Tags.First(),
                            softwareAdviceDTO.Products.First().Tags.First());
            Assert.AreEqual(softwareAdvice.Products.First().Twitter,
                            softwareAdviceDTO.Products.First().Twitter);
        }
    }
}
