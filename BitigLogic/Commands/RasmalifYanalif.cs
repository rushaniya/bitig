using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class RasmalifYanalif : SubstituteTranslitCommand
    {
        private Dictionary<string,string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            //translitTable.Add("Ä", "Ə");
            translitTable.Add("ä", "ə");
            //translitTable.Add("Ñ", "\ua790");
            translitTable.Add("ñ", "\ua791");
            //translitTable.Add("Ö", "Ɵ");
            translitTable.Add("ö", "ɵ");
            translitTable.Add("'", "’");
            translitTable.Add("iy", "i");
            translitTable.Add("üwe", "üe");
        }

        protected override Dictionary<string, string> TranslitTable
        {
            get { return translitTable; }
        }

        public RasmalifYanalif()
        {
            AlphabetPattern = @"'A-Za-zÄäÇçİıÑñÖöŞşÜü";
            CustomSourceUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
            CustomTargetUpLowPairs = TextHelper.YanalifUpperLowerPairs;
            FillTranslitTable();
            IgnoreCase = true;
        }
    }
}
