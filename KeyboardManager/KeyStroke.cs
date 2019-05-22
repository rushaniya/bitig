using System.Windows.Forms;

namespace Bitig.KeyboardManagement
{
    public class KeyStroke
    {
        public Keys MainKey { get; set; }
        public bool WithShift { get; set; }
        public bool WithCtrl { get; set; }
        public bool WithAlt { get; set; }
        public bool WithAltGr { get; set; }

        public override bool Equals(object obj)
        {
            var target = obj as KeyStroke;
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
            var hash = 0;
            hash += 3 * MainKey.GetHashCode();
            hash += 7 * WithAlt.GetHashCode();
            hash += 11 * WithAltGr.GetHashCode();
            hash += 13 * WithCtrl.GetHashCode();
            hash += 17 * WithShift.GetHashCode();
            return hash;
        }
    }
}
