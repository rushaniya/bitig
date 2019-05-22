using Bitig.Base;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlKeyboardSummary : EquatableByID<int>, IDeepCloneable<XmlKeyboardSummary>
    {
        public override int ID
        {
            get; set;
        }

        public string FriendlyName { get; set; }

        public KeyboardLayoutType Type { get; set; }

        public XmlKeyboardSummary()
        {

        }

        public XmlKeyboardSummary(KeyboardLayoutBase KeyboardLayout)
        {
            ID = KeyboardLayout.ID;
            FriendlyName = KeyboardLayout.FriendlyName;
            Type = KeyboardLayout.Type;
        }

        public XmlKeyboardSummary Clone()
        {
            return new XmlKeyboardSummary { ID = ID, FriendlyName = FriendlyName, Type = Type };
        }

        internal KeyboardLayoutSummary ToModel()
        {
            return new KeyboardLayoutSummary { FriendlyName = FriendlyName, ID = ID, Type = Type };
        }
    }
}
