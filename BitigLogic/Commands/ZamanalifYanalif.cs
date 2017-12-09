using System.Collections.Generic;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class ZamanalifYanalif : SubstituteTranslitCommand
    {
        private ExclusionCollection exclusions = new ExclusionCollection();

        //private IEqualityComparer<string> comparer;

        private Dictionary<string,string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("ä", "ə");
            translitTable.Add("â", "a");
            translitTable.Add("á", "ə");
            translitTable.Add("é", "e");
            translitTable.Add("ñ", "\ua791");
            translitTable.Add("ö", "ɵ");
            translitTable.Add("ó", "ɵ");
            translitTable.Add("ú", "ü");
            translitTable.Add("í", "ıy");
            translitTable.Add("iy", "i");
            translitTable.Add("íy", "ıy");
            translitTable.Add("'", "’");
        }


        protected override Dictionary<string, string> TranslitTable
        {
            get
            {
                return translitTable;
            }
        }

        public ZamanalifYanalif()
        {
            CustomSourceUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
            CustomTargetUpLowPairs = TextHelper.YanalifUpperLowerPairs;
            FillTranslitTable();
            IgnoreCase = true;
        }

        protected override string AlphabetPattern
        {
            get
            {
                return @"'A-Za-zÄäÂâÁáÇçÉéĞğİıÍíÑñÖöÓóŞşÜüÚú";
            }
        }
    }
}
