namespace DataAccessLayer.Executors
{
    using System.Data.SQLite;
    using Dapper;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories.Interfaces;

    public class SqlProductItemExecutor : ISqlExecutor<ProductItemModel>
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
    }
}