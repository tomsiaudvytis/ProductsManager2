﻿using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using FakeItEasy;
using NLog;
using NUnit.Framework;

namespace Tests.DataAccessLayerTests
{
    [TestFixture]
    public class SQLiteRepositoryTests
    {
        [Test]
        public void AddProductItem_ShouldCallAddFromSqliteRepository()
        {
            ISqlExecutor<ProductItemModel> productItemExecutor = A.Fake<ISqlExecutor<ProductItemModel>>();
            ILogger logger = A.Fake<ILogger>();
            ProductItemModel item = A.Fake<ProductItemModel>();
        }
    }
}