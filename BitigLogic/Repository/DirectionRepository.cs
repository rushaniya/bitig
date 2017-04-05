using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class DirectionRepository : IRepository<Direction, int>
    {
        public virtual RepositoryProvider RepositoryProvider { get; set; }

        public abstract List<Direction> GetList();
        public abstract Direction Get(int ID);
        public abstract bool IsEmpty();

        public abstract void Insert(Direction Item);
        public abstract void Delete(Direction Item);
        public abstract void Update(Direction Item);

        public abstract bool IsFlushable { get; }
        public abstract void SaveChanges();
        
        public abstract void InsertBuiltIn(int ID, BuiltInDirection BuiltIn);

        public abstract bool IsInUse(Alifba Alifba);

        public int GenerateID(IEnumerable<int> ExsitingIDs)
        {
            int _result = -1;
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (ExsitingIDs.All(_id => _id != i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }

        protected int GenerateDirectionID()
        {
            var _list = GetList();
            var _existingIDs = _list.Select(_dir => _dir.ID);
            return GenerateID(_existingIDs);
        }
    }
}
