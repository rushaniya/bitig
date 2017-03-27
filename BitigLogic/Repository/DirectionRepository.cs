using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class DirectionRepository : IRepository<Direction, int>
    {
        protected void EnsureDefaults()
        {
            var _list = GetListNoCreate();
            if (_list == null || _list.Count == 0)
            {
                CreateDefaultConfiguration();
            }
        }

        protected abstract void CreateDefaultConfiguration();

        public virtual List<Direction> GetList()
        {
            EnsureDefaults();
            return GetListNoCreate();
        }

        protected abstract List<Direction> GetListNoCreate();

        public abstract bool IsFlushable { get; }

        public abstract void Delete(Direction Item);
        public abstract int GenerateID(IEnumerable<int> ExsitingIDs);
        public abstract Direction Get(int ID);
        public abstract void Insert(Direction Item);
        public abstract void SaveChanges();
        public abstract void Update(Direction Item);

        public abstract Direction GetByAlifbaIDs(int SourceID, int TargetID);
        public abstract List<Alifba> GetTargets(int SourceID);
        public abstract bool IsInUse(int AlifbaID);
    }
}
