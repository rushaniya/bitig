using System.Collections.Generic;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class YanalifRasmalif : SubstituteTranslitCommand
    {
        private Dictionary<string, string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("\u0259", "ä");
            translitTable.Add("\ua791", "ñ");
            translitTable.Add("ɵ", "ö");
            translitTable.Add("’", "\'");
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get { return translitTable; }
        }

        public YanalifRasmalif()
        {
            AlphabetPattern = "'’A-Za-zƏəİıƟɵÜüÇçŞş\ua790\ua791";
            CustomSourceUpLowPairs = TextHelper.YanalifUpperLowerPairs;
            CustomTargetUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
            FillTranslitTable();
            IgnoreCase = true;
        }
    }
}
