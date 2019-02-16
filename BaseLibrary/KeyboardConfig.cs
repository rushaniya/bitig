using System.Collections.Generic;

namespace Bitig.Base
{
    public class KeyboardConfig
    {
        public List<KeyCombinationConfig> KeyCombinations { get; set; }
    }

    public class KeyCombinationConfig
    {
        public string MainKey { get; set; }
        public bool WithShift { get; set; }
        public bool WithCtrl { get; set; }
        public bool WithAlt { get; set; }
        public bool WithAltGr { get; set; }
        public string Result { get; set; }
    }
}
