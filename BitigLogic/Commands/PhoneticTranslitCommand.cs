using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public abstract class PhoneticTranslitCommand : SubstituteTranslitCommand
    {
        protected override string SubstituteCharacters(string Fragment)
        {
            StringBuilder _resultBuilder = new StringBuilder();
            bool _mimicCapitals = false;
            for (int i = 0; i < Fragment.Length; i++)
            {
                string _key;
                if (i + 1 < Fragment.Length)
                {
                    _key = Fragment[i].ToString() + Fragment[i + 1].ToString();
                    if (TranslitTable.ContainsKey(_key))
                    {
                        i++; //skip next character
                        _resultBuilder.Append(TranslitTable[_key]);
                        _mimicCapitals = _mimicCapitals || TranslitTable[_key].Length > 1;
                        continue;
                    }
                }
                _key = Fragment[i].ToString();
                if (TranslitTable.ContainsKey(_key))
                {
                    _resultBuilder.Append(TranslitTable[_key]);
                    _mimicCapitals = _mimicCapitals || TranslitTable[_key].Length > 1;
                }
                else
                    _resultBuilder.Append(_key);
            }
            return _mimicCapitals 
                ? TextHelper.MimicCapitals(Fragment, _resultBuilder.ToString(), CustomSourceUpLowPairs, CustomSourceUpLowPairs)
                : _resultBuilder.ToString();
        }
    }
}
