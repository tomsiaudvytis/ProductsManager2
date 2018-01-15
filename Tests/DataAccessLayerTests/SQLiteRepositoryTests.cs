using DataAccessLayer;
using DataAccessLayer.Models;
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
        public void AddProductItem_ShouldCallAddFromSqliteRepository()
        {
            ISqlExecutor<ProductItemModel> productItemExecutor = A.Fake<ISqlExecutor<ProductItemModel>>();
            ILogger logger = A.Fake<ILogger>();
            ProductItemModel item = A.Fake<ProductItemModel>();
        }
    }
}