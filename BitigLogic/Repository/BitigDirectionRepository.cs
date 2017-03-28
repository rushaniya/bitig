using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    /// <summary>
    /// Repository with business logic
    /// </summary>
    public class BitigDirectionRepository : DirectionRepository
    {
        private readonly DirectionRepository directionRepository;
       // private readonly AlifbaRepository alifbaRepository;

        public override bool IsFlushable
        {
            get
            {
                return directionRepository.IsFlushable;
            }
        }

        public BitigDirectionRepository(DirectionRepository InnerRepository)//, AlifbaRepository AlifbaRepository)
        {
            directionRepository = InnerRepository;
            //alifbaRepository = AlifbaRepository;
        }

        private void EnsureDefaults()
        {
            if (directionRepository.IsEmpty())
            {
                CreateDefaultConfiguration();
            }
        }

        public override List<Direction> GetList()
        {
            EnsureDefaults();
            return directionRepository.GetList();
        }

        public override Direction Get(int ID)
        {
            EnsureDefaults();
            var _result = directionRepository.Get(ID);
            return _result;
        }

        public override void Insert(Direction Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            EnsureDefaults();
            Item.ID = GenerateDirectionID();
            if (directionRepository.Get(Item.ID) != null)
                throw new Exception("Same ID exists."); //loc
            var _sameIDs = GetByAlifbaIDs(Item.Source.ID, Item.Target.ID);
            if (_sameIDs != null)
                throw new Exception("Direction with same source and target exists."); //loc
            directionRepository.Insert(Item);
        }

        public override void Delete(Direction Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            EnsureDefaults();
            directionRepository.Delete(Item);
        }

        public override void Update(Direction Item)
        {
            EnsureDefaults();
            directionRepository.Update(Item);
        }

        public override void SaveChanges()
        {
            directionRepository.SaveChanges();
        }

        protected void CreateDefaultConfiguration()
        {
            int _count = DefaultConfiguration.BuiltInDirections.Count;
            for (int i = 0; i < _count; i++)
            {
                directionRepository.InsertBuiltIn(i, DefaultConfiguration.BuiltInDirections[i]);
            }
            if (directionRepository.IsFlushable)
                directionRepository.SaveChanges();
        }

        public Direction GetByAlifbaIDs(int SourceID, int TargetID)
        {
            EnsureDefaults();
            var _list = directionRepository.GetList();
            var _direction = _list.SingleOrDefault(_dir =>
              _dir.Source.ID == SourceID && _dir.Target.ID == TargetID);
            return _direction;
        }

        public List<Alifba> GetTargets(int SourceID)
        {
            EnsureDefaults();
            var _list = directionRepository.GetList();
            var _targets = _list.Where(_item =>
               _item.Source.ID == SourceID).Select(_item => _item.Target).ToList();
            return _targets;
        }

        public override bool IsEmpty()
        {
            return directionRepository.IsEmpty();
        }

        public override void InsertBuiltIn(int ID, BuiltInDirection BuiltIn)
        {
            directionRepository.InsertBuiltIn(ID, BuiltIn);
        }
    }
}
