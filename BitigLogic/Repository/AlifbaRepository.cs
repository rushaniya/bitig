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
            if (alifbaRepository.GetList().Count == 0)
            {
                CreateDefaultConfiguration();
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
            if (_result == null && ID == DefaultConfiguration.YANALIF)
            {
                CreateYanalif();
                _result = alifbaRepository.Get(ID);
            }
            return _result;
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
            if (Item.ID == DefaultConfiguration.YANALIF)
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

        public Alifba Yanalif
        {
            get
            {
                return Get(DefaultConfiguration.YANALIF);
            }
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
            foreach (var _alif in DefaultConfiguration.BuiltInAlifbaList)
            {
                alifbaRepository.Insert(_alif);
            }
            if (alifbaRepository.IsFlushable)
                alifbaRepository.SaveChanges();
        }

        protected void CreateYanalif()
        {
            alifbaRepository.Insert(DefaultConfiguration.Yanalif);
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
