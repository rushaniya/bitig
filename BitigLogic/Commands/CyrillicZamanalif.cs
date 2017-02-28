using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;

namespace Bitig.Logic.Commands
{
    public class CyrillicZamanalif : TranslitCommand
    {
        private TranslitCommand cyrillicTranscription = new CyrillicTranscription();
        private PhoneticZamanalif phoneticZamanalif = new PhoneticZamanalif();

        public CyrillicZamanalif()
        {
            AlphabetPattern = @"А-яЁёӘәӨөҮүҖҗҢңҺһ";
            ChainedCommands = new List<TranslitCommand> { cyrillicTranscription, phoneticZamanalif };
            CustomTargetUpLowPairs = TextHelper.YanalifUpperLowerPairs;
        }
    }
}
