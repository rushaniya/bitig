using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Bitig.Base
{
    public class ExclusionCollection : IList<Exclusion>
    {
        private List<Exclusion> innerList;

        public IEnumerable<string> SourceWords
        {
            get
            {
                var _source = from _excl in innerList
                              select _excl.SourceWord;
                return _source;
            }
        }

        public IEnumerable<string> TargetWords
        {
            get
            {
                var _target = from _excl in innerList
                              select _excl.TargetWord;
                return _target;
            }
        }

        public IEnumerable<Exclusion> MatchCaseItems
        {
            get
            {
                var _match = from _excl in innerList
                             where _excl.MatchCase
                             select _excl;
                return _match;
            }
        }

        public IEnumerable<Exclusion> IgnoreCaseItems
        {
            get
            {
                return innerList.Where(_excl => !_excl.MatchCase);
            }
        }

        public IEnumerable<Exclusion> MatchWholeWordItems
        {
            get
            {
                var _match = from _excl in innerList
                             where _excl.MatchWholeWord
                             select _excl;
                return _match;
            }
        }

        public IEnumerable<Exclusion> MatchBeginningItems
        {
            get
            {
                return innerList.Where(_excl => _excl.MatchBeginning && !_excl.AnyPosition);
            }
        }

        public IEnumerable<Exclusion> AnyPositionItems
        {
            get
            {
                return innerList.Where(_excl => _excl.AnyPosition);
            }
        }

        public ExclusionCollection()
        {
            this.innerList = new List<Exclusion>();
        }

        public ExclusionCollection(List<Exclusion> SourceCollection)
        {
            this.innerList = SourceCollection;
        }

        public void Add(string SourceWord, string TargetWord, bool MatchCase, bool MatchBeginning, bool AnyPosition)
        {
            innerList.Add(new Exclusion(SourceWord, TargetWord, MatchCase, MatchBeginning, AnyPosition));
        }


        #region IList<Exclusion> Members

        public int IndexOf(Exclusion item)
        {
            return innerList.IndexOf(item);
        }

        public void Insert(int index, Exclusion item)
        {
            innerList.Insert(index, item);
        }

        Exclusion IList<Exclusion>.this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                innerList[index] = value;
            }
        }

        #endregion

        #region ICollection<Exclusion> Members

        public void Add(Exclusion item)
        {
            innerList.Add(item);
        }

        public bool Contains(Exclusion item)
        {
            return innerList.Contains(item);
        }

        public void CopyTo(Exclusion[] array, int arrayIndex)
        {
            innerList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Exclusion item)
        {
            return innerList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Clear()
        {
            innerList.Clear();
        }

        public int Count
        {
            get
            {
                return innerList.Count;
            }
        }

        #endregion

        #region IEnumerable<Exclusion> Members

        IEnumerator<Exclusion> IEnumerable<Exclusion>.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        #endregion
    }

}
