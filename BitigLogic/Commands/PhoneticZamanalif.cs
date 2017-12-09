using System.Collections.Generic;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    class PhoneticZamanalif : PhoneticTranslitCommand
    {
        private Dictionary<string, string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("A", "Ä");
            translitTable.Add("a", "ä");
            translitTable.Add("A:", "A");
            translitTable.Add("a:", "a");
            translitTable.Add("A^:", "Â");
            translitTable.Add("a^", "â");
            translitTable.Add("A'", "Á");
            translitTable.Add("a'", "á");
            translitTable.Add("C$", "Ç");
            translitTable.Add("c$", "ç");
            translitTable.Add("E:", "I");
            translitTable.Add("e:", "ı");
            translitTable.Add("E'", "É");
            translitTable.Add("e'", "é");
            translitTable.Add("G:", "Ğ");
            translitTable.Add("g:", "ğ");
            translitTable.Add("I", "İ");
            translitTable.Add("I:", "Í");
            translitTable.Add("i:", "í");
            translitTable.Add("N$", "Ñ");
            translitTable.Add("n$", "ñ");
            translitTable.Add("O", "Ö");
            translitTable.Add("o", "ö");
            translitTable.Add("O:", "O");
            translitTable.Add("o:", "o");
            translitTable.Add("O'", "Ó");
            translitTable.Add("o'", "ó");
            translitTable.Add("S$", "Ş");
            translitTable.Add("s$", "ş");
            translitTable.Add("S'", "Ş");
            translitTable.Add("s'", "ş");
            translitTable.Add("U", "Ü");
            translitTable.Add("u", "ü");
            translitTable.Add("U:", "U");
            translitTable.Add("u:", "u");
            translitTable.Add("U'", "Ú");
            translitTable.Add("u'", "ú");
            translitTable.Add("~", "'");
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get { return translitTable; }
        }

        public PhoneticZamanalif()
        {
            FillTranslitTable();
            CustomTargetUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
        }

        protected override string Translit(string Fragment, bool WordStart, bool WholeWord)
        {
            var result = base.Translit(Fragment, WordStart, WholeWord);
            return TrimYots(result);
        }

        private string TrimYots(string Fragment)
        {
            return Fragment.Replace("ÍY", "Í").Replace("Íy", "Í").Replace("íy", "í").Replace("íY", "í");
        }
    }
}
