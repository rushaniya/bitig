using System.Collections.Generic;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class CyrillicYanalif : TranslitCommand
    {
        private TranslitCommand cyrillicTranscription = new CyrillicTranscription();
        private PhoneticYanalif phoneticYanalif = new PhoneticYanalif();

        public CyrillicYanalif()
        {
            AlphabetPattern = @"А-яЁёӘәӨөҮүҖҗҢңҺһ";
            ChainedCommands = new List<TranslitCommand> { cyrillicTranscription, phoneticYanalif };
            CustomTargetUpLowPairs = TextHelper.YanalifUpperLowerPairs;
        }
    }
}
