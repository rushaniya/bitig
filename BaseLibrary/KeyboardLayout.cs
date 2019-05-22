using System.Collections.Generic;
using System.Windows.Forms;

namespace Bitig.Base
{
    public class KeyboardLayout : KeyboardLayoutBase
    {
        public List<KeyCombination> KeyCombinations { get; set; }

        public override KeyboardLayoutType Type
        {
            get
            {
                return KeyboardLayoutType.Full;
            }
        }
    }

    public class KeyCombination
    {
        public Keys MainKey { get; set; }
        public bool WithShift { get; set; }
        public bool WithCtrl { get; set; }
        public bool WithAlt { get; set; }
        public bool WithAltGr { get; set; }
        public string Result { get; set; }
        public string Capital { get; set; }
    }    
}
