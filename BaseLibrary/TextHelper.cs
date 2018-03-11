using System;
using System.Collections.Generic;
using System.Linq;

namespace Bitig.Base
{
    public static class TextHelper
    {
        private static Dictionary<char, char> yanalifUpperLowerPairs;

        public static Dictionary<char, char> YanalifUpperLowerPairs
        {
            get { return TextHelper.yanalifUpperLowerPairs; }
        }

        private static Dictionary<char, char> zamanalifUpperLowerPairs;

        public static Dictionary<char, char> ZamanalifUpperLowerPairs
        {
            get { return TextHelper.zamanalifUpperLowerPairs; }
        }

        static TextHelper()
        {
            FillYanalifPairs();
            FillZamanalifPairs();
        }

        private static void FillYanalifPairs()
        {
            yanalifUpperLowerPairs = new Dictionary<char, char>();
            yanalifUpperLowerPairs.Add('İ', 'i');
            yanalifUpperLowerPairs.Add('I', 'ı');
            yanalifUpperLowerPairs.Add('\ua790', '\ua791');
        }

        private static void FillZamanalifPairs()
        {
            zamanalifUpperLowerPairs = new Dictionary<char, char>();
            zamanalifUpperLowerPairs.Add('İ', 'i');
            zamanalifUpperLowerPairs.Add('I', 'ı');
        }

        public static void DefineCapitals(string Word, out bool LowerCase, out bool FirstCapital, out bool AllCapitals)
        {
            FirstCapital = AllCapitals = false;
            LowerCase = true;
            var _hasLetters = false;
            for (int i = 0; i < Word.Length; i++)
            {
                if (!char.IsLetter(Word[i]))
                    continue;
                _hasLetters = true;
                if (char.IsUpper(Word[i]))
                {
                    if (i == 0)
                    {
                        FirstCapital = true;
                        LowerCase = false;
                    }
                }
                else
                {
                    return;
                }
            }
            AllCapitals = _hasLetters;
        }

        public static void DefineCapitals(string Word, IEnumerable<char> UpperChars, IEnumerable<char> LowerChars, out bool LowerCase, out bool FirstCapital, out bool AllCapitals)
        {
            FirstCapital = AllCapitals = false;
            LowerCase = true;
            var _hasCapitals = false;
            for (int i = 0; i < Word.Length; i++)
            {
                var _currentChar = Word[i];
                if (UpperChars != null && UpperChars.Contains(_currentChar))
                {
                    _hasCapitals = true;
                    if (i == 0)
                    {
                        FirstCapital = true;
                        LowerCase = false;
                    }
                }
                else
                {
                    if (LowerChars != null && LowerChars.Contains(_currentChar))
                        return;
                    if (char.IsLetter(_currentChar))
                    {
                        if (char.IsUpper(_currentChar))
                        {
                            _hasCapitals = true;
                            if (i == 0)
                            {
                                FirstCapital = true;
                                LowerCase = false;
                            }
                        }
                        else return;
                    }
                    else continue;
                }
            }
            AllCapitals = _hasCapitals;
        }

      /*  public static string MimicCapitals(string CopyFrom, string CopyTo, CultureInfo TargetCulture)
        {
            if (string.IsNullOrEmpty(CopyFrom))
                return CopyTo;
            else
            {
                bool _lower, _allCaps, _firstCap;
                DefineCapitals(CopyFrom, out _lower, out _firstCap, out _allCaps);
                if (_allCaps) return CopyTo.ToUpper(TargetCulture);
                if (_firstCap) return char.ToUpper(CopyTo[0], TargetCulture) + CopyTo.Substring(1);
                return CopyTo;
            }
        }*/

        public static string MimicCapitals(string CopyFrom, string CopyTo)
        {
            if (string.IsNullOrEmpty(CopyFrom))
                return CopyTo;
            else
            {
                bool _lower, _allCaps, _firstCap;
                DefineCapitals(CopyFrom, out _lower, out _firstCap, out _allCaps);
                if (_allCaps) return CopyTo.ToUpperInvariant();
                if (_firstCap) return char.ToUpperInvariant(CopyTo[0]) + CopyTo.Substring(1);
                return CopyTo;
            }
        }

        public static string MimicCapitals(string CopyFrom, string CopyTo, Dictionary<char, char> SourceUpperLowerPairs, Dictionary<char, char> TargetUpperLowerPairs)
        {
            if (string.IsNullOrEmpty(CopyFrom))
                return CopyTo;
            else
            {
                bool _lower, _allCaps, _firstCap;
                if (SourceUpperLowerPairs == null || SourceUpperLowerPairs.Count == 0) 
                    DefineCapitals(CopyFrom, out _lower, out _firstCap, out _allCaps);
                else 
                    DefineCapitals(CopyFrom, SourceUpperLowerPairs.Keys, SourceUpperLowerPairs.Values, out _lower, out _firstCap, out _allCaps);
                if (_allCaps) 
                    return ToUpper(CopyTo, TargetUpperLowerPairs);
                if (_firstCap) 
                    return ToUpper(CopyTo[0], TargetUpperLowerPairs) + CopyTo.Substring(1);
                //return CopyTo;
                return ToLower(CopyTo, TargetUpperLowerPairs);
            }
        }

        public static char ToUpper(char Source, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0)
                return char.ToUpperInvariant(Source);
            if (UpperLowerPairs.ContainsKey(Source))
                return Source;
            var _lowerMatch = UpperLowerPairs.FirstOrDefault(_pair => _pair.Value == Source).Key;
            if (_lowerMatch != (char)0)
                return _lowerMatch;
            return char.ToUpperInvariant(Source);
        }

        public static string ToUpper(string Source, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0) return Source.ToUpperInvariant();
            return ToUpperPrivate(Source, UpperLowerPairs);
        }

        private static string ToUpperPrivate(string Source, Dictionary<char, char> UpperLowerPairs)
        {
            if (string.IsNullOrEmpty(Source))
                return string.Empty;
            var _originalChars = Source.ToCharArray();
            var _length = _originalChars.Length;
            var _upperChars = new char[_length];
            for (int i = 0; i < _length; i++)
            {
                _upperChars[i] = ToUpper(_originalChars[i], UpperLowerPairs);
            }
            return new string(_upperChars);
        }

        public static char ToLower(char Source, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0)
                return char.ToLowerInvariant(Source);
            if (UpperLowerPairs.ContainsKey(Source))
                return UpperLowerPairs[Source];
            if (UpperLowerPairs.ContainsValue(Source))
                return Source;
            return char.ToLowerInvariant(Source);
        }

        public static string ToLower(string Source, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0)
                return Source.ToLowerInvariant();
            return ToLowerPrivate(Source, UpperLowerPairs);
        }

        private static string ToLowerPrivate(string Source, Dictionary<char, char> UpperLowerPairs)
        {
            if (string.IsNullOrEmpty(Source))
                return string.Empty;
            var _originalChars = Source.ToCharArray();
            var _length = _originalChars.Length;
            var _lowerChars = new char[_length];
            for (int i = 0; i < _length; i++)
            {
                _lowerChars[i] = ToLower(_originalChars[i], UpperLowerPairs);
            }
            return new string(_lowerChars);
        }

        public static bool IsLower(char Character, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs.ContainsValue(Character)) return true;
            if (UpperLowerPairs.ContainsKey(Character)) return false;
            return char.IsLower(Character);
        }

        public static bool EqualsIgnoreCase(string First, string Second, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0) 
                return string.Equals(First, Second, StringComparison.InvariantCultureIgnoreCase);
            string _firstLower = ToLowerPrivate(First, UpperLowerPairs);
            string _secondLower = ToLowerPrivate(Second, UpperLowerPairs);
            return string.Equals(_firstLower, _secondLower, StringComparison.InvariantCulture);
        }

        public static bool StartsWithIgnoreCase(string Whole,string Part, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0) 
                return Whole.StartsWith(Part, StringComparison.InvariantCultureIgnoreCase);
            string _wholeLower = ToLowerPrivate(Whole, UpperLowerPairs);
            string _partLower = ToLowerPrivate(Part, UpperLowerPairs);
            return _wholeLower.StartsWith(_partLower, StringComparison.InvariantCulture);
        }

        public static int IndexOfIgnoreCase(string Whole,string Part, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0) 
                return Whole.IndexOf(Part, StringComparison.InvariantCultureIgnoreCase);
            string _wholeLower = ToLowerPrivate(Whole, UpperLowerPairs);
            string _partLower = ToLowerPrivate(Part, UpperLowerPairs);
            return _wholeLower.IndexOf(_partLower, StringComparison.InvariantCulture);
        }

        public static int IndexOfIgnoreCase(string Whole, string Part, int StartIndex, Dictionary<char, char> UpperLowerPairs)
        {
            if (UpperLowerPairs == null || UpperLowerPairs.Count == 0) 
                return Whole.IndexOf(Part, StartIndex, StringComparison.InvariantCultureIgnoreCase);
            string _fromStartIndexLower = ToLowerPrivate(Whole.Substring(StartIndex), UpperLowerPairs);
            string _partLower = ToLowerPrivate(Part, UpperLowerPairs);
            int _index = _fromStartIndexLower.IndexOf(_partLower, StringComparison.InvariantCulture);
            if (_index < 0) return -1;
            return StartIndex + _index;
        }
    }
}
