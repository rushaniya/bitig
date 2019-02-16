using System;
using System.Windows.Forms;

namespace KeyboardManager
{
    public class KeyCombination
    {
        public Keys MainKey { get; set; }
        public bool WithShift { get; set; }
        public bool WithCtrl { get; set; }
        public bool WithAlt { get; set; }
        public bool WithAltGr { get; set; }

        public override bool Equals(object obj)
        {
            var target = obj as KeyCombination;
            if (target == null)
                return false;
            return target.MainKey == MainKey &&
                target.WithAlt == WithAlt &&
                target.WithAltGr == WithAltGr &&
                target.WithCtrl == WithCtrl &&
                target.WithShift == WithShift;
        }

        public override int GetHashCode()
        {
            var _hash = 0;
            _hash += 3 * MainKey.GetHashCode();
            _hash += 7 * WithAlt.GetHashCode();
            _hash += 11 * WithAltGr.GetHashCode();
            _hash += 13 * WithCtrl.GetHashCode();
            _hash += 17 * WithShift.GetHashCode();
            return _hash;
        }

        public static Keys ConvertToKeysEnum(string keyName)
        {
            throw new NotImplementedException();
            keyName = keyName.ToUpperInvariant();
            if (keyName.Length == 1)
            {

            }
        }
    }
}
