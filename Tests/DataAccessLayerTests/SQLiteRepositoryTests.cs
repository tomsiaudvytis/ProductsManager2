using DataAccessLayer;
using DataAccessLayer.Executors;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using FakeItEasy;
using NLog;
using NUnit.Framework;
using System;

namespace Tests.DataAccessLayerTests
{
    [TestFixture]
    public class SQLiteRepositoryTests
    {
        string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop, Environment.SpecialFolderOption.Create) + $@"\TestSqlRepoDb.db";

        [SetUp]
        public void InitTestDb()
        {
            Helper.CreateDatabase(dbPath);
        }

        [TearDown]
        public void DeleteTestDatabase()
        {
            Helper.DeleteDatabase(dbPath);
        }

        [Test]
        public void AddProductItem_Adding_Dublicate_Returns_Exception()
        {
            ISqlExecutor<ProductItemModel> productItemExecutor = new SqlProductItemExecutor();
            ILogger logger = A.Fake<ILogger>();
            SQLiteRepository repo = new SQLiteRepository(productItemExecutor, logger);

            ProductItemModel item = new ProductItemModel
            {
                Id = Guid.NewGuid(),
                MeasurementUnit = "Kg",
                ProductName = "bulves"
            };

            repo.AddProductItem(item);
            repo.AddProductItem(item);

        }
    }
}