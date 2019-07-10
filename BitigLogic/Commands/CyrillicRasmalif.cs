using System.Collections.Generic;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class CyrillicRasmalif : TranslitCommand
    {
        private TranslitCommand cyrillicTranscription = new CyrillicTranscription();
        private PhoneticRasmalif phoneticRasmalif = new PhoneticRasmalif();

        public CyrillicRasmalif()
        {
            AlphabetPattern = @"А-яЁёӘәӨөҮүҖҗҢңҺһ"; 
            ChainedCommands = new List<TranslitCommand> { cyrillicTranscription, phoneticRasmalif };
            CustomTargetUpLowPairs = TextHelper.ZamanalifUpperLowerPairs;
        }
    }
}
