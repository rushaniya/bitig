﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;
using Bitig.Logic.Model;

namespace Bitig.Logic.Commands
{
    public class ConfigurableTranslitCommand : SubstituteTranslitCommand
    {
        private Dictionary<string, string> translitTable = new Dictionary<string, string>();

        public ConfigurableTranslitCommand(Dictionary<TextSymbol, TextSymbol> SymbolMapping)
        {
            var _alphabetPatternBuilder = new StringBuilder();
            CustomSourceUpLowPairs = new Dictionary<char, char>();
            CustomTargetUpLowPairs = new Dictionary<char, char>();
            var _uniqueChars = new List<char>();
            foreach (var _source in SymbolMapping.Keys)
            {
                if (string.IsNullOrEmpty(_source.ActualText))
                    throw new InvalidOperationException("Source lower symbol must not be empty.");
                var _target = SymbolMapping[_source];
                if (_target == null || string.IsNullOrEmpty(_target.ActualText))
                    throw new InvalidOperationException("Target lower symbol must not be empty.");

                var _normalized = _source.ActualText.Normalize();
                var _chars = _normalized.ToCharArray();
                foreach (var _char in _chars)
                {
                    if (!_uniqueChars.Contains(_char))
                        _uniqueChars.Add(_char);
                }
                if (!string.IsNullOrEmpty(_source.CapitalizedText))
                {
                    _normalized = _source.CapitalizedText.Normalize();
                    _chars = _normalized.ToCharArray();
                    foreach (var _char in _chars)
                    {
                        if (!_uniqueChars.Contains(_char))
                            _uniqueChars.Add(_char);
                    }
                }

                //if CapitalizedText is missing, the upper case is from invariant culture
                //or, if actual text consists of more than 1 symbol, is same as actual text
                var _upperSource = _source.CapitalizedText;
                if (string.IsNullOrEmpty(_upperSource))
                {
                    if (_source.ActualText.Length == 1)
                        _upperSource = _source.ActualText.ToUpperInvariant();
                    else
                        _upperSource = _source.ActualText;
                }
                else if (_source.ActualText.Length == 1 && _upperSource.Length == 1)
                {
                    //if it is a single letter, we're filling CustomSourceUpLowPairs
                    var _invariantUpper = _source.ActualText.ToUpperInvariant();
                    if (_invariantUpper != _upperSource && !CustomSourceUpLowPairs.ContainsKey(_upperSource[0]))
                    {
                        CustomSourceUpLowPairs.Add(_upperSource[0], _source.ActualText[0]);
                    }
                }

                var _upperTarget = _target.CapitalizedText;
                if (string.IsNullOrEmpty(_upperTarget))
                {
                    if (_target.ActualText.Length == 1)
                        _upperTarget = _target.ActualText.ToUpperInvariant();
                    else
                        _upperTarget = _target.ActualText;
                }
                else if (_target.ActualText.Length == 1 && _upperTarget.Length == 1)
                {
                    //if it is a single letter, we're filling CustomTargetUpLowPairs
                    var _invariantUpper = _target.ActualText.ToUpperInvariant();
                    if (_invariantUpper != _upperTarget && !CustomTargetUpLowPairs.ContainsKey(_upperTarget[0]))
                    {
                        CustomTargetUpLowPairs.Add(_upperTarget[0], _target.ActualText[0]);
                    }
                }
                translitTable.Add(_source.ActualText, _target.ActualText);
            }
            AlphabetPattern = _uniqueChars.Select(c => "\\u" + ((int)c).ToString("X4")).Aggregate((first, second) => first + second);
            IgnoreCase = true;
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get
            {
                return translitTable;
            }
        }
    }
}
