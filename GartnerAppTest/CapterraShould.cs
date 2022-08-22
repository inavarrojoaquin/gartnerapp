﻿namespace GartnerAppTest
{
    public class CapterraShould
    {
        [Test]
        public void GenerateAsExpected()
        {

            List<CapterraItemDTO> capterraList = new List<CapterraItemDTO>
            {
                new CapterraItemDTO
                {
                    Name = "Name1",
                    Tags = "Tag1",
                    Twitter = "Twitter1"
                },
                new CapterraItemDTO
                {
                    Name = "Name2",
                    Tags = "Tag2",
                    Twitter = "Twitter2"
                }
            };
            
            Capterra capterra = new Capterra(capterraList);

            Assert.IsNotNull(capterra.Products);
            Assert.That(capterra.Products.Count, Is.EqualTo(2));
            Assert.AreEqual(capterra.Products.First().Name,
                            capterraList.First().Name);
            Assert.AreEqual(capterra.Products.First().Tags.First(),
                            capterraList.First().Tags);
            Assert.AreEqual(capterra.Products.First().Twitter,
                            capterraList.First().Twitter);
        }
    }
}
