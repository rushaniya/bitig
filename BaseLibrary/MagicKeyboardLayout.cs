using System.Collections.Generic;
using System.Windows.Forms;

namespace Bitig.Base
{
    public class MagicKeyboardLayout : KeyboardLayoutBase
    {
        public Keys MagicKey { get; set; }
        public List<MagicKeyCombination> KeyCombinations { get; set; }

        public override KeyboardLayoutType Type
        {
            get
            {
                return KeyboardLayoutType.Magic;
            }
        }
    }

    public class MagicKeyCombination
    {
        public char Symbol { get; set; }
        public string WithMagic { get; set; }
    }
}
