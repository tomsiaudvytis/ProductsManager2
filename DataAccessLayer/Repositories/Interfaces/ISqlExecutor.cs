namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ISqlExecutor<T>
    {
        void Add(string sqlCommand);
        int GetCount(string sqlCommand);
    }
}
