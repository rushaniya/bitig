using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class AlifbaRepository : IRepository<Alifba, int>
    {
        private readonly  IRepository<Alifba, int> alifbaRepository;

        public AlifbaRepository(IRepository<Alifba, int> innerRepository)
        {
            alifbaRepository = innerRepository;
        }

        private void EnsureDefaults()
        {
            var _list = alifbaRepository.GetList();
            if (_list.Count == 0)
            {
                CreateDefaultConfiguration();
            }
            else
            {
                if (!_list.Any(_alif => _alif.BuiltIn == BuiltInAlifbaType.Yanalif))
                {
                    var _id = alifbaRepository.GenerateID(_list.Select(_item => _item.ID));
                    CreateYanalif(_id);
                }
            }
        }

        public List<Alifba> GetList()
        {
            EnsureDefaults();
            return alifbaRepository.GetList();
        }

        public Alifba Get(int ID)
        {
            EnsureDefaults();
            var _result = alifbaRepository.Get(ID);
            return _result;
        }

        public Alifba GetBuiltIn(BuiltInAlifbaType BuiltIn) //repo: generic filter
        {
            EnsureDefaults();
            var _list = alifbaRepository.GetList();
            return _list.SingleOrDefault(_alif => _alif.BuiltIn == BuiltIn);
        }

        public void Insert(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            EnsureDefaults();
            Item.ID = GenerateAlifbaID();
            if (alifbaRepository.Get(Item.ID) != null)
                throw new Exception("Same ID exists.");
            alifbaRepository.Insert(Item);
        }

        public void Delete(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            if (Item.BuiltIn == BuiltInAlifbaType.Yanalif)
                throw new InvalidOperationException("Cannot delete Yanalif.");
            if (RepositoryProvider == null)
                throw new Exception("RepositoryProvider is null. Cannot access DirectionRepository.");
            EnsureDefaults();
            if (RepositoryProvider.DirectionRepository.IsInUse(Item))
                throw new Exception("Cannot delete alphabet in use.");
            alifbaRepository.Delete(Item);
        }

        public void Update(Alifba Item)
        {
            EnsureDefaults();
            alifbaRepository.Update(Item);
        }

        public Alifba GetYanalif()
        {
            return GetBuiltIn(BuiltInAlifbaType.Yanalif);
        }

        public bool IsFlushable
        {
            get
            {
                return alifbaRepository.IsFlushable;
            }
        }

        public RepositoryProvider RepositoryProvider
        {
            get
            {
                return alifbaRepository.RepositoryProvider;
            }

            set
            {
                alifbaRepository.RepositoryProvider = value;
            }
        }

        protected void CreateDefaultConfiguration()
        {
            var _IDs = new List<int>();
            foreach (var _builtIn in DefaultConfiguration.BuiltInAlifbaList)
            {
                var _id = alifbaRepository.GenerateID(_IDs);
                _IDs.Add(_id);
                var _alifba = new Alifba(_id, _builtIn.DefaultName, _builtIn.CustomSymbols, 
                    _builtIn.RightToLeft, _builtIn.DefaultFont, _builtIn.ID);
                alifbaRepository.Insert(_alifba);
            }
            if (alifbaRepository.IsFlushable)
                alifbaRepository.SaveChanges();
        }

        protected void CreateYanalif(int ID)
        {
            var _yanalif = new Alifba(ID, DefaultConfiguration.Yanalif.DefaultName, DefaultConfiguration.Yanalif.CustomSymbols,
                    DefaultConfiguration.Yanalif.RightToLeft, DefaultConfiguration.Yanalif.DefaultFont, DefaultConfiguration.Yanalif.ID);
            alifbaRepository.Insert(_yanalif);
            if (alifbaRepository.IsFlushable)
                alifbaRepository.SaveChanges();
        }

        public bool IsEmpty()
        {
            return alifbaRepository.GetList().Count == 0;
        }

        public void SaveChanges()
        {
            if (!alifbaRepository.IsFlushable)
                throw new InvalidOperationException("Repository does not support flushing.");
            alifbaRepository.SaveChanges();
        }

        public int GenerateID(IEnumerable<int> ExistingIDs)
        {
            return alifbaRepository.GenerateID(ExistingIDs);
        }


        private int GenerateAlifbaID()
        {
            var _list = GetList();
            var _existingIDs = _list.Select(_alif => _alif.ID);
            return alifbaRepository.GenerateID(_existingIDs);
        }
    }
}
