using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class InMemoryRepository<T, IDType> : IRepository<T, IDType>
        where T:EquatableByID<IDType>, IDeepCloneable<T> 
    {
        private List<InMemoryItem<T>> list;
        private IRepository<T, IDType> persistentRepo;

        public bool IsFlushable
        {
            get
            {
                return true;
            }
        }

        public RepositoryProvider RepositoryProvider
        {
            get { return persistentRepo.RepositoryProvider; } //repo: ok?
            set { persistentRepo.RepositoryProvider = value; }
        }

        public InMemoryRepository(IRepository<T, IDType> PersistentRepository)
        {
            if (PersistentRepository == null)
                throw new ArgumentNullException("PersistentRepository");
            persistentRepo = PersistentRepository;
            FillList();
        }

        private void FillList()
        {
            list = new List<InMemoryItem<T>>();
            var _persistentList = persistentRepo.GetList();
            foreach(var _item in _persistentList)
            {
                list.Add(new InMemoryItem<T>(_item));
            }
        }

        private IDType GenerateID()
        {
            return persistentRepo.GenerateID(list.Select(_item => _item.Item.ID));
        }

        public void Insert(T Item)
        {
            Item.ID = GenerateID();
            var _clone = Item.Clone();
            //if (Item.ID.Equals(IDGenerator.DefaultID))
            //    _clone.ID = IDGenerator.GenerateID(GetList());
            //else
            //    list.RemoveAll(_item => _item.Item.Equals(Item));
            var _added = new InMemoryItem<T>(_clone);
            _added.State = ItemState.Added;
            list.Add(_added);
        }

        public void Update(T Item)
        {
            var _existingItem = list.Find(_item => _item.Item.Equals(Item));
            if (_existingItem == null)
            {
                throw new InvalidOperationException("Item does not exist.");
            }
            var _currentState = _existingItem.State;
            if (_currentState== ItemState.Deleted)
            {
                throw new InvalidOperationException("Item deleted.");
            }
            list.Remove(_existingItem);
            var _updated = new InMemoryItem<T>(Item.Clone());
            _updated.State = _currentState == ItemState.Unmodified ? ItemState.Updated : _currentState;
            list.Add(_updated);
        }

        public void Delete(T Item)
        {
            var _existingItem = list.Find(_item => _item.Item.Equals(Item));
            if(_existingItem != null)
            {
                if (_existingItem.State == ItemState.Added)
                    list.Remove(_existingItem);
                else
                    _existingItem.State = ItemState.Deleted;
            }
        }

        public List<T> GetList()
        {
            return list.Where(_item => _item.State != ItemState.Deleted).Select(_item => _item.Item.Clone()).ToList();
        }

        public T Get(IDType ID)
        {
            var _found = list.Find(_item => _item.Item.ID.Equals(ID));
            if (_found == null || _found.State == ItemState.Deleted)
                return null;
            return _found.Item.Clone();
        }

        public void SaveChanges()
        {
            foreach (var _item in list)
            {
                switch(_item.State)
                {
                    case ItemState.Added:
                        persistentRepo.Insert(_item.Item);
                        break;
                    case ItemState.Updated:
                        persistentRepo.Update(_item.Item);
                        break;
                    case ItemState.Deleted:
                        persistentRepo.Delete(_item.Item);
                        break;
                }
                _item.State = ItemState.Unmodified;
            }
            if (persistentRepo.IsFlushable)
                persistentRepo.SaveChanges();
        }

        public IDType GenerateID(IEnumerable<IDType> ExistingIDs)
        {
            return persistentRepo.GenerateID(ExistingIDs);
        }
    }

    public class InMemoryItem<T>
    {
        public T Item { get; private set; }
        public ItemState State { get; set; }

        public InMemoryItem(T Item)
        {
            this.Item = Item;
            this.State = ItemState.Unmodified;
        }
    }

    public enum ItemState
    {
        Unmodified,
        Added,
        Updated,
        Deleted
    }
}
