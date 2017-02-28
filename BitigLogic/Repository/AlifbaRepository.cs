using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class AlifbaRepository : IRepository<Alifba, int>
    {
        public List<Alifba> GetList()
        {
            var _list = GetListNoCreate();
            if (_list == null || _list.Count == 0)
            {
                CreateDefaultConfiguration();
                _list = GetListNoCreate();
            }
            return _list;
        }

        protected abstract List<Alifba> GetListNoCreate();

        public virtual void Insert(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            Item.ID = GenerateAlifbaID();
            InsertExactID(Item);
        }

        protected abstract void InsertExactID(Alifba Item);

        public abstract void Update(Alifba Item);
        public abstract void Delete(Alifba Item);

        public Alifba Get(int ID)
        {
            var _result = GetNoCreate(ID);
            if (_result == null && ID == DefaultConfiguration.YANALIF)
            {
                var _list = GetListNoCreate();
                if (_list == null || _list.Count == 0)
                    CreateDefaultConfiguration();
                else
                    CreateYanalif();
                _result = GetNoCreate(ID);
            }
            return _result;
        }

        protected abstract Alifba GetNoCreate(int ID);

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
            int _result = -1;
            var _list = GetList();
            for (int i = DefaultConfiguration.MIN_CUSTOM_ID; i < int.MaxValue; i++)
            {
                if (!_list.Exists(_alif => _alif.ID == i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }

        public int GenerateID(IEnumerable<int> ExsitingIDs)
        {
            int _result = -1;
            //var _list = GetList();
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
