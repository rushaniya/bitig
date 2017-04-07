using System.Collections.Generic;

namespace Bitig.Logic.Repository
{
    public interface IRepository<T, IDType> where T:IRepositoryItem<IDType>
    {
        RepositoryProvider RepositoryProvider { get; set; }
        void Insert(T Item);
        void Update(T Item);
        void Delete(T Item);
        bool IsFlushable { get; }
        void SaveChanges();
        List<T> GetList();
        T Get(IDType ID);
        IDType GenerateID(IEnumerable<IDType> ExistingIDs);
    }
}
