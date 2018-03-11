using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bitig.Base
{
    public abstract class TranslitCommand
    {
        /// <summary>
        /// \p{L} by default
        /// </summary>
        protected virtual string AlphabetPattern { get; set; }

        // protected virtual string TranslitPattern { get; set; }

        /// <summary>
        /// Empty by default
        /// </summary>
        public virtual ExclusionCollection Exclusions
        {
            get;
            set;
        }

        protected List<TranslitCommand> ChainedCommands
        {
            get;
            set;
        }

        protected Dictionary<char, char> CustomSourceUpLowPairs
        {
            get;
            set;
        }

        protected Dictionary<char, char> CustomTargetUpLowPairs
        {
            get;
            set;
        }

        protected TranslitCommand()
        {
            AlphabetPattern = @"\p{L}";
            Exclusions = new ExclusionCollection();
        }

        public virtual string Convert(string Text)
        {
            Text = Text.Normalize();
            bool _isChained = ChainedCommands != null && ChainedCommands.Count > 0;
            if (_isChained)
                return ChainConvert(Text);
            StringBuilder _resultBuilder = new StringBuilder();
            List<bool> _alphaMapping;
            List<string> _alphaGroups = GetMatchingFragments(Text, AlphabetPattern, out _alphaMapping);
            for (int i = 0; i < _alphaGroups.Count; i++)
            {
                string _resultWord;
                if (_alphaMapping[i])
                {
                    _resultWord = TranslitOrFindExclusion(_alphaGroups[i], true, true);
                }
                else
                {
                    _resultWord = Translit(_alphaGroups[i], false, false);
                }
                _resultBuilder.Append(_resultWord);
            }
            return _resultBuilder.ToString();
        }

        protected virtual string ChainConvert(string Text)
        {
            StringBuilder _resultBuilder = new StringBuilder();
            List<bool> _mapping;
            List<string> _groups = GetMatchingFragments(Text, AlphabetPattern, out _mapping);
            for (int i = 0; i < _groups.Count; i++)
            {
                string _resultWord;
                if (_mapping[i])
                {
                    _resultWord = ChainTranslitOrFindExclusion(_groups[i]);
                }
                else
                {
                    _resultWord = Translit(_groups[i], false, false);
                }
                _resultBuilder.Append(_resultWord);
            }
            return _resultBuilder.ToString();
        }

        protected virtual string TranslitOrFindExclusion(string Word, bool WordStart, bool WholeWord)
        {
            List<bool> _exclMapping;
            List<string> _parts = SearchForExclusions(Word, WordStart, WholeWord, out _exclMapping);
            if (_parts.Count == 1)
            {
                if (_exclMapping[0])
                    return _parts[0];//return exact exclusion
                return Translit(_parts[0], true, true);
            }
            string _result = string.Empty;
            for (int i = 0; i < _parts.Count; i++)
            {
                if (_exclMapping[i])//this is exclusion
                {
                    _result += _parts[i];
                }
                else
                {
                    string _converted = Translit(_parts[i], i == 0, false);
                    _result = AppendTranslittedFragment(_result, _converted);
                }
            }
            return _result;
        }

        private string ChainTranslitOrFindExclusion(string Word)
        {
            List<bool> _exclMapping;
            List<string> _parts = SearchForExclusions(Word, true, true, out _exclMapping);
            if (_parts.Count == 1)
            {
                string _chainResult = _parts[0]; //if this is exclusion, return exact exclusion
                if (!_exclMapping[0])
                {
                    for (int i = 0; i < ChainedCommands.Count; i++)
                    {
                        _chainResult = ChainedCommands[i].TranslitOrFindExclusion(_chainResult, true, true); 
                    }
                }
                return _chainResult;
            }
            string _result = string.Empty;
            for (int i = 0; i < _parts.Count; i++)
            {
                if (_exclMapping[i])//this is exclusion
                {
                    _result += _parts[i];
                }
                else
                {
                    string _converted = _parts[i];
                    for (int j = 0; j < ChainedCommands.Count; j++)
                    {
                        _converted = ChainedCommands[j].TranslitOrFindExclusion(_converted, i == 0, false);
                    }
                    _result = AppendTranslittedFragment(_result, _converted);
                }
            }
            return _result;
        }

        protected virtual string AppendTranslittedFragment(string Previous, string Current)
        {
            return string.Concat(Previous, Current);
        }

        private string GetSplitPattern(string Pattern)
        {
            return string.Format("([^{0}]*)([{0}]*)", Pattern);
        }

        private string GetMatchPattern(string Pattern)
        {
            return string.Format("[{0}]+", Pattern);
        }

        protected virtual string Translit(string Fragment, bool WordStart, bool WholeWord)
        {
            return Fragment;
        }

        private List<string> GetMatchingFragments(string Text, string Pattern, out List<bool> Mapping)
        {
            var _splitPattern = GetSplitPattern(Pattern);
            var _regex = new Regex(_splitPattern);
            MatchCollection _groups = _regex.Matches(Text);
            Mapping = new List<bool>();
            List<string> _result = new List<string>();
            foreach (Match _symbolGroup in _groups)
            {
                if (!string.IsNullOrEmpty(_symbolGroup.Groups[1].Value))//non-matching symbols
                {
                    _result.Add(_symbolGroup.Groups[1].Value);
                    Mapping.Add(false);
                }
                if (!string.IsNullOrEmpty(_symbolGroup.Groups[2].Value))//matching symbols
                {
                    _result.Add(_symbolGroup.Groups[2].Value);
                    Mapping.Add(true);
                }
            }
            return _result;
        }

        protected virtual List<string> SearchForExclusions(string Word, bool WordStart, bool WholeWord, out List<bool> ExclusionsMapping)
        {
            var _foundExclusions = new SortedDictionary<int, FoundExclusion>();
            ExclusionsMapping = new List<bool>();
            List<string> _fragments = new List<string>();
            IEnumerable<Exclusion> _exclusions = Exclusions.AnyPositionItems;
            if (WordStart)
                _exclusions = _exclusions.Union(Exclusions.MatchBeginningItems);
            if (WholeWord)
                _exclusions = _exclusions.Union(Exclusions.MatchWholeWordItems);
            foreach (Exclusion _excl in _exclusions)
            {
                if (string.IsNullOrEmpty(_excl.SourceWord))
                    continue;
                GetExclusionOccurences(Word, _excl, _foundExclusions);
            }
            if (_foundExclusions.Count == 0)
            {
                _fragments.Add(Word);
                ExclusionsMapping.Add(false);
            }
            else
            {
                var _dictCounter = 0;
                foreach(var _entry in _foundExclusions)
                {
                    if (_dictCounter == 0 && _entry.Key > 0)
                    {
                        _fragments.Add(Word.Substring(0, _entry.Key));
                        ExclusionsMapping.Add(false);
                    }
                    _fragments.Add(_entry.Value.Target);
                    ExclusionsMapping.Add(true);
                    string _nextFragment;
                    if (_dictCounter + 1 >= _foundExclusions.Count) //last found exclusion
                        _nextFragment = Word.Substring(_entry.Key + _entry.Value.SourceLength);
                    else
                    {
                        var _nextKey = _foundExclusions.Keys.Where(_key => _key > _entry.Key).Min();
                        var _currentPos = _entry.Key + _entry.Value.SourceLength;
                        _nextFragment = Word.Substring(_currentPos, _nextKey - _currentPos);
                    }
                    if (_nextFragment.Length > 0)
                    {
                        _fragments.Add(_nextFragment);
                        ExclusionsMapping.Add(false);
                    }
                    _dictCounter++;
                }
            }
            return _fragments;
        }

        private void GetExclusionOccurences(string Word, Exclusion Exclusion, SortedDictionary<int, FoundExclusion> FoundExclusions)
        {
            int _nextStart = 0;
            int _limit = Word.Length - Exclusion.SourceWord.Length;
            int _index;
            //find all occurrences of this exclusion
            while (true)
            {
                if (_nextStart > _limit)
                {
                    break;
                }
                _index = Exclusion.MatchCase ?
                    Word.IndexOf(Exclusion.SourceWord, _nextStart, StringComparison.InvariantCulture) ://excl: CultureInfo field in TranslitCommand?
                    TextHelper.IndexOfIgnoreCase(Word, Exclusion.SourceWord, _nextStart, CustomSourceUpLowPairs);
                if (_index < 0)
                    break;
                var _sourceLength = Exclusion.SourceWord.Length;
                if (FindIntersections(_index, _sourceLength, FoundExclusions))
                    break;
                int _exclusionEnd = _index + Exclusion.SourceWord.Length;
                if (Exclusion.AnyPosition ||
                    _index == 0 && (Exclusion.MatchBeginning || _exclusionEnd == Word.Length))
                {
                    //match found
                    _nextStart = _exclusionEnd;
                    if (Exclusion.MatchCase)
                    {
                        FoundExclusions.Add(_index, new FoundExclusion { Target = Exclusion.TargetWord, SourceLength = _sourceLength });
                    }
                    else
                    {
                        FoundExclusions.Add(_index, new FoundExclusion
                        {
                            SourceLength = _sourceLength,
                            Target = MimicCapitals(Word.Substring(_index, _sourceLength), Exclusion.TargetWord)
                        });
                    }
                }
                else
                    _nextStart++;
            }
        }

        private bool FindIntersections(int Index, int Length, IDictionary<int, FoundExclusion> ExistingExclusions)
        {
            if (ExistingExclusions.ContainsKey(Index))
                return true;
            foreach(var _entry in ExistingExclusions)
            {
                if (Index > _entry.Key)
                {
                    if (Index < _entry.Key + _entry.Value.SourceLength)
                        return true;
                }
                else
                {
                    if (Index + Length > _entry.Key)
                        return true;
                }
            }
            return false;
        }

        protected virtual string MimicCapitals(string CopyFrom, string CopyTo)
        {
            return TextHelper.MimicCapitals(CopyFrom, CopyTo, CustomSourceUpLowPairs, CustomTargetUpLowPairs);
        }

        struct FoundExclusion
        {
            public int SourceLength;
            public string Target;
        }

        public bool ConflictsWithExistingExclusions(Exclusion Exclusion, out List<Exclusion> Conflicts)
        {
            Conflicts = new List<Exclusion>();
            if (Exclusions != null)
            {
                var _foundExclusions = new SortedDictionary<int, FoundExclusion>();
                foreach (var _excl in Exclusions)
                {
                    if (_excl.Equals(Exclusion))
                        continue;
                    GetExclusionOccurences(Exclusion.SourceWord, _excl, _foundExclusions);
                    if (_foundExclusions.Count > 0)
                        Conflicts.Add(_excl);
                    _foundExclusions.Clear();
                }
            }
            return Conflicts.Count > 0;
        }

        public bool IsAlphabetic(string Fragment)
        {
            var _matchPattern = GetMatchPattern(AlphabetPattern);
            return Regex.IsMatch(Fragment, _matchPattern);
        }

        public virtual bool IsValidExclusion(Exclusion Exclusion, out List<string> Errors, out List<string> Warnings)
        {
            Warnings = new List<string>();
            Errors = new List<string>();
            if (string.IsNullOrEmpty(Exclusion.SourceWord))
            {
                Errors.Add("Source word is empty.");
                return false;
            }
            if (Exclusion.SourceWord.Length < 2)
            {
                Errors.Add("Source word is too short.");
                return false;
            }
            if (!IsAlphabetic(Exclusion.SourceWord))
            {
                Errors.Add("Source word contains non-alphabetical symbols.");
                return false;
            }
            List<Exclusion> _conflicts;
            if(ConflictsWithExistingExclusions(Exclusion, out _conflicts))
            {
                foreach (var _excl in _conflicts)
                {
                    Warnings.Add(string.Format("Intersects with exclusion: {0} - {1}", _excl.SourceWord, _excl.TargetWord));
                }
            }
            
            return true;
        }
    }

}
