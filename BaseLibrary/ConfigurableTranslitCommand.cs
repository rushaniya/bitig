using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Base
{
    //custom:
   /* class ConfigurableTranslitCommand : SubstituteTranslitCommand
    {
        protected override string SubstituteCharacters(string Text)
        {
            var _keyGroups = (from _entry in TranslitTable
                              group _entry by _entry.Key.Length into _group
                              orderby _group.Key descending
                              select new { KeyLength = _group.Key, Entries = _group.ToList() })
                             .ToList();
            var _minLength = _keyGroups[_keyGroups.Count() - 1].KeyLength;
            StringBuilder _resultBuilder = new StringBuilder();
            var i = 0;
            while (i < Text.Length)
            {
                string _sourceFragment;
                foreach (var _group in _keyGroups)
                {
                    _sourceFragment = Text.Substring(i, _group.KeyLength);
                    var _translitKey = _group.Entries.Find(_entry => TextHelper.EqualsIgnoreCase(
                        _entry.Key, _sourceFragment, CustomSourceUpLowPairs)); //excl: IEqualityComparer in Dictionary ctor?
                    if (!_translitKey.Equals(default(KeyValuePair<string,string>)))
                    {
                        var _mimic = TextHelper.MimicCapitals(_sourceFragment, _translitKey.Value, CustomSourceUpLowPairs, CustomTargetUpLowPairs);
                        _resultBuilder.Append(_mimic);
                        i += _group.KeyLength;
                        break;
                    }
                    if (_group.KeyLength == _minLength)
                    {
                        _resultBuilder.Append(_sourceFragment);
                        i += _group.KeyLength;
                    }
                }
            }
            return _resultBuilder.ToString();
        }
    }*/
}
