using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Base
{
    public abstract class SubstituteTranslitCommand : TranslitCommand
    {
        private class TranslitKeyGroup
        {
            public int KeyLength { get; set; }
            public Dictionary<string, string> Entries { get; set; }
        }

        private List<TranslitKeyGroup> keyGroups;

        protected abstract Dictionary<string, string> TranslitTable { get; }

        protected override string Translit(string Fragment, bool WordStart, bool WholeWord)
        {
            return SubstituteCharacters(Fragment);
        }

        protected bool IgnoreCase { get; set; }

        private Dictionary<string, string> ignoreCaseTranslitTable;

        protected virtual string SubstituteCharacters(string Fragment)
        {
            Dictionary<string, string> _translitTable;
            if (IgnoreCase)
            {
                if (ignoreCaseTranslitTable == null)
                {
                    var comparer = new IgnoreCaseComparer(CustomSourceUpLowPairs);
                    ignoreCaseTranslitTable = new Dictionary<string, string>(TranslitTable, comparer);
                }
                _translitTable = ignoreCaseTranslitTable;
            }
            else
            {
                _translitTable = TranslitTable;
            }

            if (keyGroups == null)
            {
                keyGroups = (from _entry in _translitTable
                             group _entry by _entry.Key.Length into _group
                             orderby _group.Key descending
                             select new TranslitKeyGroup
                             {
                                 KeyLength = _group.Key,
                                 Entries = _group.Select(_g => _g)
                                 .ToDictionary(_key => _key.Key, _value => _value.Value, _translitTable.Comparer)
                             })
                             .ToList();
            }
            var _minLength = keyGroups[keyGroups.Count() - 1].KeyLength;
            StringBuilder _resultBuilder = new StringBuilder();
            var i = 0;
            var exactKey = true;
            while (i < Fragment.Length)
            {
                string _sourceFragment;
                foreach(var _group in keyGroups)
                {
                    if (i + _group.KeyLength - 1 >= Fragment.Length)
                        continue;
                    _sourceFragment = Fragment.Substring(i, _group.KeyLength);
                    if (_group.Entries.ContainsKey(_sourceFragment))
                    {
                        var _target = _group.Entries[_sourceFragment];
                        _resultBuilder.Append(_target);
                        i += _group.KeyLength;
                        exactKey = exactKey && TranslitTable.ContainsKey(_sourceFragment);
                        break;
                    }
                    if (_group.KeyLength == _minLength)
                    {
                        _resultBuilder.Append(_sourceFragment);
                        i += _group.KeyLength;
                    }
                }
            }
            var _result = _resultBuilder.ToString();
            if (!exactKey)
                _result = MimicCapitals(Fragment, _result);
            return _result;
        }
    }
}
