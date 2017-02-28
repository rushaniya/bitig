using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Repository
{
    public interface IRepository<T, IDType> where T:EquatableByID<IDType>
    {
        void Insert(T Item);
        void Update(T Item);
        void Delete(T Item);
        bool IsFlushable { get; }
        void SaveChanges();
        List<T> GetList();
        T Get(IDType ID);
        //IIDGenerator<T, IDType> IDGenerator { get; }
       // IDType DefaultID { get; }
        IDType GenerateID(IEnumerable<IDType> ExsitingIDs);
    }
}
