using System;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlAlifba : EquatableByID<int>, IDeepCloneable<XmlAlifba>
    {
        public override int ID
        {
            get;
            set;
        }

        public string FriendlyName
        {
            get;
            set;
        }

        public int? KeyboardLayoutID
        {
            get;
            set;
        }

        public XmlFont DefaultFont
        {
            get;
            set;
        }

        public bool RightToLeft
        {
            get;
            set;
        }

        public BuiltInAlifbaType BuiltIn { get; set; }

        [Obsolete("For XML serialization only")]
        public XmlAlifba()
        {
           
        }

        public XmlAlifba(int ID, string FriendlyName,
            bool RightToLeft = false, XmlFont DefaultFont = null, BuiltInAlifbaType BuiltIn = BuiltInAlifbaType.None,
            int? KeyboardLayoutID = null)
        {
            this.ID = ID;
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
            this.BuiltIn = BuiltIn;
            this.KeyboardLayoutID = KeyboardLayoutID;
        }

        public XmlAlifba(Alifba ModelAlifba)
        {
            ID = ModelAlifba.ID;
            FriendlyName = ModelAlifba.FriendlyName;
            RightToLeft = ModelAlifba.RightToLeft;
            if (ModelAlifba.DefaultFont != null)
                DefaultFont = new XmlFont { Description = ModelAlifba.DefaultFont.Description };
            BuiltIn = ModelAlifba.BuiltIn;
            KeyboardLayoutID = ModelAlifba.KeyboardLayoutID;
        }

        public Alifba ToShallowModel()
        {
            var _defaultFont = DefaultFont == null ? null : new AlifbaFont(DefaultFont.Description);
            var _alifba = new Alifba(ID, FriendlyName,
                null, RightToLeft, _defaultFont, BuiltIn, KeyboardLayoutID);
            return _alifba;
        }

        public override string ToString()
        {
            return FriendlyName;
        }

        public override bool Equals(object obj)
        {
            XmlAlifba _cast = obj as XmlAlifba;
            if (_cast == null) return false;
            return _cast.ID == ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public XmlAlifba Clone()
        {
         
            var _clonedFont = DefaultFont == null ? null :
                new XmlFont { Description = DefaultFont.Description };
            return new XmlAlifba(ID, FriendlyName, RightToLeft, _clonedFont, BuiltIn, KeyboardLayoutID);
        }
    }
}
