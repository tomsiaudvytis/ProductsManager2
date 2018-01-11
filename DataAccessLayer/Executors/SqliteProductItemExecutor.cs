namespace DataAccessLayer.Executors
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using Dapper;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories.Interfaces;

    public class SqliteProductItemExecutor : ISqliteExecutor<ProductItemModel>
    {
        public void Add(string sqlCommand)
        {
            using (var connection = new SQLiteConnection(Helper.DbConnection()))
            {
                connection.Query(sqlCommand);
            }
        }

        public int GetCount(string sqlCommand)
        {
            using (var connection = new SQLiteConnection(Helper.DbConnection()))
            {
                return connection.ExecuteScalar<int>(sqlCommand);
            }
        }

        public void Delete(string sqlCommand)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductItemModel> Save(string sqlCommand)
        {
            throw new System.NotImplementedException();
        }

        public ProductItemModel Update(string sqlCommand)
        {
            throw new System.NotImplementedException();
        }
    }
}