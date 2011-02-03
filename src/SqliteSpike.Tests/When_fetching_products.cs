using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using NUnit.Framework;
using SqliteSpike.Data;
using SqliteSpike.Entities;

namespace SqliteSpike.Tests
{
    [TestFixture]
    public class When_fetching_products : TestBase
    {        
        [Test]
        public void Should_return_data_created_in_test_scope()
        {
            Product product = CreateProduct();
            var persistenceProvider = new PersistenceProvider<Product>();
            persistenceProvider.Save(product);

            var fetchedProducts = new PersistenceProvider<Product>().FetchAll();

            Assert.That(fetchedProducts.Count, Is.EqualTo(1));
            Assert.That(fetchedProducts[0].Releases.Count(), Is.EqualTo(4));
            Assert.That(fetchedProducts[0].Tags.Count(), Is.EqualTo(2));

            Assert.That(new PersistenceProvider<Tag>().FetchAll().Count, Is.EqualTo(2));
            Assert.That(new PersistenceProvider<Release>().FetchAll().Count, Is.EqualTo(4));
        }

        [Test]
        public void Should_have_empty_database_for_a_new_test()
        {
            Assert.That(new PersistenceProvider<Product>().FetchAll().Count, Is.EqualTo(0));
            Assert.That(new PersistenceProvider<Tag>().FetchAll().Count, Is.EqualTo(0));
            Assert.That(new PersistenceProvider<Release>().FetchAll().Count, Is.EqualTo(0));
        }

        private Product CreateProduct()
        {
            List<Tag> tags = CreateTags();
            List<Release> releases = CreateReleases();
            
            return CreateProduct(tags, releases);
        }

        private List<Release> CreateReleases()
        {
            var releases = new List<Release>
            {
               new Release{ Title = Guid.NewGuid().ToString()},
               new Release{ Title = Guid.NewGuid().ToString()},
               new Release{ Title = Guid.NewGuid().ToString()},
               new Release{ Title = Guid.NewGuid().ToString()}

            };

            return releases;
        }

        private Product CreateProduct(IEnumerable<Tag> tags, ICollection<Release> releases)
        {
            var product = new Product
            {
                Title = Guid.NewGuid().ToString(),
                Tags = tags,
                Releases = releases
            };
            product.Tags.ForEach(x => x.Products = new List<Product> { product });
            product.Releases.ForEach(x => x.Product =  product);

            return product;
        }

        private List<Tag> CreateTags()
        {
            return new List<Tag> { new Tag { Name = Guid.NewGuid().ToString() }, new Tag { Name = Guid.NewGuid().ToString() } };
        }
    }
}