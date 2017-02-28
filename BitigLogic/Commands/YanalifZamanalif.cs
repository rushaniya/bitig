using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class YanalifZamanalif : SubstituteTranslitCommand
    {
        private Dictionary<string, string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("ə", "ä");
            translitTable.Add("\ua791", "ñ");
            translitTable.Add("ɵ", "ö");
            translitTable.Add("ıy", "í");
            translitTable.Add("’", "\'");
            translitTable.Add("iy", "i");
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get { return translitTable; }
        }

        public YanalifZamanalif()
        {
            AlphabetPattern = @"'’A-Za-zƏəİıƟɵÜüÇçŞş\ua790\ua791";
            CustomSourceUpLowPairs = TextHelper.YanalifUpperLowerPairs;
            CustomTargetUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
            FillTranslitTable();
            IgnoreCase = true;
        }
    }
}
