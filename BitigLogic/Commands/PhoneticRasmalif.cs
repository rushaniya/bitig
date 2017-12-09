using System.Collections.Generic;
using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    class PhoneticRasmalif : PhoneticTranslitCommand
    {
        private Dictionary<string, string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("A", "Ä");
            translitTable.Add("a", "ä");
            translitTable.Add("A:", "A");
            translitTable.Add("a:", "a"); 
            translitTable.Add("A^:", "A");
            translitTable.Add("a^", "a");
            translitTable.Add("C$", "Ç");
            translitTable.Add("c$", "ç");
            translitTable.Add("E:", "I");
            translitTable.Add("e:", "ı");
            translitTable.Add("E'", "E");
            translitTable.Add("e'", "e");
            translitTable.Add("G:", "Ğ");
            translitTable.Add("g:", "ğ");
            translitTable.Add("I", "İ");
            translitTable.Add("I:", "I");
            translitTable.Add("i:", "ı");
            translitTable.Add("N$", "Ñ");
            translitTable.Add("n$", "ñ");
            translitTable.Add("O", "Ö");
            translitTable.Add("o", "ö");
            translitTable.Add("O:", "O");
            translitTable.Add("o:", "o");
            translitTable.Add("S$", "Ş");
            translitTable.Add("s$", "ş");
            translitTable.Add("S'", "Şç");
            translitTable.Add("s'", "şç");
            translitTable.Add("U", "Ü");
            translitTable.Add("u", "ü");
            translitTable.Add("U:", "U");
            translitTable.Add("u:", "u");
            translitTable.Add("~", "'");
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get { return translitTable; }
        }

        public PhoneticRasmalif()
        {
            FillTranslitTable();
            AlphabetPattern = @"А-яЁёӘәӨөҮүҖҗҢңҺһ";//excl:set this in Alifba class?
            CustomTargetUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
        }

        protected override string SubstituteCharacters(string Fragment)
        {
            StringBuilder _resultBuilder = new StringBuilder();
            for (int i = 0; i < Fragment.Length; i++)
            {
                string _key;
                if (i + 1 < Fragment.Length)
                {
                    _key = Fragment[i].ToString() + Fragment[i + 1].ToString();
                    if (TranslitTable.ContainsKey(_key))
                    {
                        i++; //skip next character
                        _resultBuilder.Append(SelectCase(_key, Fragment));
                        continue;
                    }
                }
                _key = Fragment[i].ToString();
                if (TranslitTable.ContainsKey(_key))
                    _resultBuilder.Append(SelectCase(_key, Fragment));
                else
                    _resultBuilder.Append(_key);
            }
            return _resultBuilder.ToString();
        }

        private string SelectCase(string Key, string Fragment)
        {
            var _value = translitTable[Key];
            if (_value.Length > 1)
            {
                bool _allCapitals, _firstCapital, _lowerCase;
                TextHelper.DefineCapitals(Fragment, out _lowerCase, out _firstCapital, out _allCapitals);
                if (_allCapitals)
                    _value = TextHelper.ToUpper(_value, CustomTargetUpLowPairs);
            }
            return _value;
        }
    }
}
