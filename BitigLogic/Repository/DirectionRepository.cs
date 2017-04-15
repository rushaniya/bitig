using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    /// <summary>
    /// Repository with business logic
    /// </summary>
    public class DirectionRepository : IRepository<Direction, int>
    {
        private readonly IRepository<Direction, int> directionRepository;

        public bool IsFlushable
        {
            get
            {
                return directionRepository.IsFlushable;
            }
        }

        public RepositoryProvider RepositoryProvider
        {
            get
            {
                return directionRepository.RepositoryProvider;
            }

            set
            {
                directionRepository.RepositoryProvider = value;
            }
        }

        public DirectionRepository(IRepository<Direction, int> InnerRepository)
        {
            directionRepository = InnerRepository;
            //alifbaRepository = AlifbaRepository;
        }

        private void EnsureDefaults()
        {
            if (directionRepository.GetList().Count == 0)
            {
                CreateDefaultConfiguration();
            }
        }

        public List<Direction> GetList()
        {
            EnsureDefaults();
            return directionRepository.GetList();
        }

        public Direction Get(int ID)
        {
            EnsureDefaults();
            var _result = directionRepository.Get(ID);
            return _result;
        }

        public void Insert(Direction Item)
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

        public void Delete(Direction Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            EnsureDefaults();
            directionRepository.Delete(Item);
        }

        public void Update(Direction Item)
        {
            EnsureDefaults();
            directionRepository.Update(Item);
        }

        public int GenerateID(IEnumerable<int> ExistingIDs)
        {
            return directionRepository.GenerateID(ExistingIDs);
        }

        private int GenerateDirectionID()
        {
            var _list = GetList();
            var _existingIDs = _list.Select(_dir => _dir.ID);
            return directionRepository.GenerateID(_existingIDs);
        }

        public void SaveChanges()
        {
            directionRepository.SaveChanges();
        }

        private void CreateDefaultConfiguration()
        {
            if (RepositoryProvider == null)
                throw new Exception("RepositoryProvider is null. Cannot access AlifbaRepository.");
            int _count = DefaultConfiguration.BuiltInDirections.Count;
            for (int i = 0; i < _count; i++)
            {
                var _builtIn = DefaultConfiguration.BuiltInDirections[i];
                var _source = RepositoryProvider.AlifbaRepository.GetBuiltIn(_builtIn.Source);
                var _target = RepositoryProvider.AlifbaRepository.GetBuiltIn(_builtIn.Target);
                if (_source != null && _target != null)
                {
                    var _direction = new Direction(i, _source, _target, null, BuiltIn: _builtIn);
                    directionRepository.Insert(_direction);
                }
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

        public bool IsInUse(Alifba Alifba)
        {
            EnsureDefaults();
            var _list = directionRepository.GetList();
            return _list.Any(_dir =>
              _dir.Source.ID == Alifba.ID || _dir.Target.ID == Alifba.ID);
        }
    }
}
