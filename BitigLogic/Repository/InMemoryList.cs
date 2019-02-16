using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bitig.Logic.Repository
{
    public class InMemoryList<T> : IEnumerable<InMemoryItem<T>>
        where T:EquatableByID<int>, IDeepCloneable<T>
    {
        private List<InMemoryItem<T>> list;

        public event Action<int, int> IDChanged;
        public event Func<int, T> NotFound;

        public InMemoryList(List<T> List = null)
        {
            if (List == null)
            {
                list = new List<InMemoryItem<T>>();

            }
            else
            {
                list = List.Select(x => new InMemoryItem<T>(x)).ToList();
            }
        }

        private int GenerateTempID()
        {
            return IDGenerator.GenerateID(list.Select(x => x.Item.ID));
        }

        public void Insert(T Item)
        {
            Item.ID = GenerateTempID();
            var _clone = Item.Clone();
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

        /// <summary>
        /// Inert item with exact ID or update, if exists
        /// </summary>
        /// <param name="Item"></param>
        public void InsertOrUpdate(T Item)
        {
            var _existingItem = list.Find(_item => _item.Item.Equals(Item));
            if (_existingItem == null)
            {
                var _clone = Item.Clone();
                var _added = new InMemoryItem<T>(_clone);
                _added.State = ItemState.Added;
                list.Add(_added);
            }
            else
            {
                var _currentState = _existingItem.State;
                list.Remove(_existingItem);
                var _updated = new InMemoryItem<T>(Item.Clone());
                _updated.State = _currentState == ItemState.Unmodified ? ItemState.Updated : _currentState;
                list.Add(_updated);
            }
        }

        public void Delete(int ID)
        {
            var _existingItem = list.Find(_item => _item.Item.ID.Equals(ID));
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

        public T Get(int ID)
        {
            var _found = list.Find(_item => _item.Item.ID.Equals(ID));
            if (_found == null)
            {
                if (NotFound != null)
                {
                    var _foundElsewhere = NotFound(ID);
                    if (_foundElsewhere != null)
                    {
                        list.Add(new InMemoryItem<T>(_foundElsewhere));
                        return _foundElsewhere;
                    }
                }
                return null;
            }
            if (_found.State == ItemState.Deleted)
                return null;
            return _found.Item.Clone();
        }

        public List<T> ApplyChanges(List<T> PersistentList)
        {
            var _result = new List<T>(PersistentList);
            foreach (var _item in list)
            {
                var _persistentItem = _result.FirstOrDefault(x => x.ID == _item.Item.ID);
                switch(_item.State)
                {
                    case ItemState.Added:
                        if (_persistentItem == null)
                        {
                            _result.Add(_item.Item);
                        }
                        else
                        {
                            var _oldID = _item.Item.ID;
                            var _clone = _item.Item.Clone();
                            var _newID=IDGenerator.GenerateID(_result.Select(x => x.ID));
                            _clone.ID = _newID;
                            _result.Add(_clone);
                            IDChanged?.Invoke(_oldID, _newID);
                        }
                        break;
                    case ItemState.Updated:
                        if (_persistentItem != null)
                        {
                            _result.Remove(_persistentItem);
                            _result.Add(_item.Item);
                        }
                        break;
                    case ItemState.Deleted:
                        if (_persistentItem != null)
                        {
                            _result.Remove(_persistentItem);
                        }
                        break;
                }
                list = _result.Select(x => new InMemoryItem<T>(x)).ToList();
            }
            return _result;
        }

        public IEnumerator<InMemoryItem<T>> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void ChangeID(int OldID, int NewID)
        {
            var _found = list.Find(_item => _item.Item.ID.Equals(OldID));
            if (_found != null)
                _found.Item.ID = NewID;
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
