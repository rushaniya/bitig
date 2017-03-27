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
        protected void EnsureDefaults()
        {
            var _list = GetListNoCreate();
            if (_list == null || _list.Count == 0)
            {
                CreateDefaultConfiguration();
            }
        }

        public List<Alifba> GetList()
        {
            EnsureDefaults();
            return GetListNoCreate();
        }

        protected abstract List<Alifba> GetListNoCreate();

        public virtual void Insert(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            EnsureDefaults();
            Item.ID = GenerateAlifbaID();
            InsertExactID(Item);
        }

        protected abstract void InsertExactID(Alifba Item);

        public abstract void Update(Alifba Item);

        public virtual void Delete(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            if (Item.ID == DefaultConfiguration.YANALIF)
                throw new InvalidOperationException("Cannot delete Yanalif.");
            EnsureDefaults();
            DeleteNoCheck(Item);
        }

        protected abstract void DeleteNoCheck(Alifba Item);

        public Alifba Get(int ID)
        {
            EnsureDefaults();
            var _list = GetListNoCreate();
            var _result = GetIfExists(ID);
            if (_result == null && ID == DefaultConfiguration.YANALIF)
            {
                CreateYanalif();
                _result = GetIfExists(ID);
            }
            return _result;
        }

        protected abstract Alifba GetIfExists(int ID);

        public bool IsFlushable { get; protected set; }

        public Alifba Yanalif
        {
            get
            {
                return Get(DefaultConfiguration.YANALIF);
            }
        }

        //public IIDGenerator<Alifba, int> IDGenerator
        //{
        //    get
        //    {
        //        return DefaultConfiguration.AlifbaIDGenerator;
        //    }
        //}

        protected abstract void FlushChanges();

        public void SaveChanges()
        {
            if (!IsFlushable)
                throw new InvalidOperationException("Repository does not support flushing.");
            FlushChanges();
        }

        protected void CreateDefaultConfiguration()
        {
            foreach (var _alif in DefaultConfiguration.BuiltInAlifbaList)
            {
                InsertExactID(_alif);
            }
            if (IsFlushable)
                FlushChanges();
        }

        protected void CreateYanalif()
        {
            InsertExactID(DefaultConfiguration.Yanalif);
            if (IsFlushable)
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
