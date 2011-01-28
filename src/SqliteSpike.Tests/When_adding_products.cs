using System;
using System.Linq;
using NHibernate.Linq;
using NUnit.Framework;
using SqliteSpike.Data;
using SqliteSpike.Entities;
using System.Collections.Generic;

namespace SqliteSpike.Tests
{
    [TestFixture]
    public class When_adding_products: TestBase
    {
        [Test]
        public void Database_should_contain_product_having_added_the_product()
        {
            List<Tag> tags = CreateTags();
            List<Release> releases = CreateReleases();
            Product product = CreateProduct(tags, releases);
            

            ProductRepository repository = new ProductRepository();
            repository.Save(product);

            Product fetchedProduct = repository.FetchAll()[0];

            Assert.That(fetchedProduct, Is.Not.Null);
            Assert.That(fetchedProduct.Title, Is.EqualTo(product.Title));
            Assert.That(fetchedProduct.Tags.Count(), Is.EqualTo(2));
            Assert.That(fetchedProduct.Tags.ToList()[0].Name, Is.EqualTo(tags[0].Name));
            Assert.That(fetchedProduct.Releases.Count(), Is.EqualTo(releases.Count()));
        }

        private List<Release> CreateReleases()
        {
            return new List<Release>
            {
               new Release{ Title = "a release"},
               new Release{ Title = "second release"},
            };
        }

        private Product CreateProduct(IEnumerable<Tag> tags, IEnumerable<Release> releases)
        {
            var product = new Product
                              {
                                  Title = "Some product",
                                  Tags = tags,
                                  Releases = releases
                              };
            product.Tags.ForEach(x => x.Products = new List<Product> { product });
            product.Releases.ForEach(x => x.Product = product);
            return product;
        }

        private List<Tag> CreateTags()
        {
            return new List<Tag> {new Tag { Name = "rock"}, new Tag { Name = "trance" }};
        }
    }
}