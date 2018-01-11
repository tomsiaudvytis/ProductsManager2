namespace DataAccessLayer.Repositories.Interfaces
{
    using System.Collections.Generic;

    public interface ISqliteExecutor<T>
    {
        IEnumerable<T> Save(string sqlCommand);
        void Delete(string sqlCommand);
        T Update(string sqlCommand);
        void Add(string sqlCommand);
        int GetCount(string sqlCommand);
    }
}
