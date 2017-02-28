using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class CyrillicRasmalif : TranslitCommand
    {
        private TranslitCommand cyrillicTranscription = new CyrillicTranscription();
        private PhoneticRasmalif phoneticRasmalif = new PhoneticRasmalif();

        public CyrillicRasmalif()
        {
            AlphabetPattern = @"А-яЁёӘәӨөҮүҖҗҢңҺһ"; //excl:set this in Alifba class?
            ChainedCommands = new List<TranslitCommand> { cyrillicTranscription, phoneticRasmalif };
            CustomTargetUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
        }
    }
}
