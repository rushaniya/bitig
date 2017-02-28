using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    class PhoneticYanalif : PhoneticTranslitCommand
    {
        private Dictionary<string, string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("A", "Ə");
            translitTable.Add("a", "ə");
            translitTable.Add("A:", "A");
            translitTable.Add("a:", "a");
            translitTable.Add("A^:", "A");
            translitTable.Add("a^", "a");
            translitTable.Add("A'", "Ə");
            translitTable.Add("a'", "ə");
            translitTable.Add("C$", "Ç");
            translitTable.Add("c$", "ç");
            translitTable.Add("E:", "I");
            translitTable.Add("e:", "ı");
            //translitTable.Add("E'", "E");
            //translitTable.Add("e'", "e");
            translitTable.Add("G:", "Ğ");
            translitTable.Add("g:", "ğ");
            translitTable.Add("I", "İ");
            translitTable.Add("I:", "I");
            translitTable.Add("i:", "ı");
            translitTable.Add("N$", "\ua790");
            translitTable.Add("n$", "\ua791");
            translitTable.Add("O", "Ɵ");
            translitTable.Add("o", "ɵ");
            translitTable.Add("O:", "O");
            translitTable.Add("o:", "o");
            translitTable.Add("O'", "Ɵ");
            translitTable.Add("o'", "ɵ");
            translitTable.Add("S$", "Ş");
            translitTable.Add("s$", "ş");
            translitTable.Add("S'", "Şç");
            translitTable.Add("s'", "şç");
            translitTable.Add("U", "Ü");
            translitTable.Add("u", "ü");
            translitTable.Add("U:", "U");
            translitTable.Add("u:", "u");
            translitTable.Add("U'", "Ü");
            translitTable.Add("u'", "ü");
            translitTable.Add("~", "’");
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get { return translitTable; }
        }

        public PhoneticYanalif()
        {
            FillTranslitTable();
            CustomTargetUpLowPairs = TextHelper.YanalifUpperLowerPairs;
        }
    }
}
