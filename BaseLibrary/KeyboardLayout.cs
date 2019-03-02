using System.Collections.Generic;

namespace Bitig.Base
{
    public class KeyboardLayout
    {
        public int ID { get; set; }
        public string FriendlyName { get; set; }
        public List<KeyCombination> KeyCombinations { get; set; }
    }

    public class KeyCombination
    {
        public string MainKey { get; set; }
        public bool WithShift { get; set; }
        public bool WithCtrl { get; set; }
        public bool WithAlt { get; set; }
        public bool WithAltGr { get; set; }
        public string Result { get; set; }
    }
}
