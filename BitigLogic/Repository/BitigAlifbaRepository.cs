using System;
using System.Collections.Generic;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class BitigAlifbaRepository : AlifbaRepository
    {
        private readonly AlifbaRepository alifbaRepository;

        public BitigAlifbaRepository(AlifbaRepository innerRepository)
        {
            alifbaRepository = innerRepository;
            IsFlushable = innerRepository.IsFlushable;
        }

        private void EnsureDefaults()
        {
            if (alifbaRepository.IsEmpty())
            {
                CreateDefaultConfiguration();
            }
        }

        public override List<Alifba> GetList()
        {
            EnsureDefaults();
            return alifbaRepository.GetList();
        }

        public override Alifba Get(int ID)
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

        public override void Insert(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            EnsureDefaults();
            Item.ID = GenerateAlifbaID();
            if (alifbaRepository.Get(Item.ID) != null)
                throw new Exception("Same ID exists.");
            alifbaRepository.Insert(Item);
        }

        public override void Delete(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            if (Item.ID == DefaultConfiguration.YANALIF)
                throw new InvalidOperationException("Cannot delete Yanalif.");
            EnsureDefaults();
            alifbaRepository.Delete(Item);
        }

        public override void Update(Alifba Item)
        {
            EnsureDefaults();
            alifbaRepository.Update(Item);
        }

        protected override void FlushChanges()
        {
            alifbaRepository.SaveChanges();
        }

        public Alifba Yanalif
        {
            get
            {
                return Get(DefaultConfiguration.YANALIF);
            }
        }

        protected void CreateDefaultConfiguration()
        {
            foreach (var _alif in DefaultConfiguration.BuiltInAlifbaList)
            {
                alifbaRepository.Insert(_alif);
            }
            if (IsFlushable)
                FlushChanges();
        }

        protected void CreateYanalif()
        {
            alifbaRepository.Insert(DefaultConfiguration.Yanalif);
            if (IsFlushable)
                FlushChanges();
        }

        public override bool IsEmpty()
        {
            return alifbaRepository.IsEmpty();
        }
    }
}
