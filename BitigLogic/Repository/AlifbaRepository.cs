using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    //repo: change non-custom IDs to built-in IDs like in directions?
    //repo: is it bad to require IDs to be int? no, because ID in business entity is int
    public abstract class AlifbaRepository : IRepository<Alifba, int>
    {
        public abstract List<Alifba> GetList();

        public abstract void Insert(Alifba Item); //repo: bitig repo method (generate ID) + base repo method (assign ID)?

        public abstract void Update(Alifba Item);

        public abstract void Delete(Alifba Item);

        public abstract Alifba Get(int ID);

        public abstract bool IsEmpty();

        public bool IsFlushable { get; protected set; }

        protected abstract void FlushChanges();

        public void SaveChanges()
        {
            if (!IsFlushable)
                throw new InvalidOperationException("Repository does not support flushing.");
            FlushChanges();
        }

        protected virtual int GenerateAlifbaID()
        {
            /*int _result = -1;
            var _list = GetList();
            for (int i = DefaultConfiguration.MIN_CUSTOM_ID; i < int.MaxValue; i++)
            {
                if (!_list.Exists(_alif => _alif.ID == i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;*/
            var _list = GetList();
            var _existingIDs = _list.Select(_alif => _alif.ID);
            return GenerateID(_existingIDs);
        }

        public int GenerateID(IEnumerable<int> ExsitingIDs)
        {
            int _result = -1;
            for (int i = DefaultConfiguration.MIN_CUSTOM_ID; i < int.MaxValue; i++)
            {
                if (ExsitingIDs.All(_id => _id != i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }
    }
}
