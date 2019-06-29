using System;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlAlphabet : EquatableByID<int>, IDeepCloneable<XmlAlphabet>
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

        [Obsolete("For XML serialization only")]
        public XmlAlphabet()
        {
           
        }

        public XmlAlphabet(int ID, string FriendlyName, bool RightToLeft = false, XmlFont DefaultFont = null, int? KeyboardLayoutID = null)
        {
            this.ID = ID;
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
            this.KeyboardLayoutID = KeyboardLayoutID;
        }

        public XmlAlphabet(AlphabetSummary ModelAlphabet)
        {
            ID = ModelAlphabet.ID;
            FriendlyName = ModelAlphabet.FriendlyName;
            RightToLeft = ModelAlphabet.RightToLeft;
            if (ModelAlphabet.DefaultFont != null)
                DefaultFont = new XmlFont { Description = ModelAlphabet.DefaultFont.Description };
            KeyboardLayoutID = ModelAlphabet.KeyboardLayoutID;
        }

        public AlphabetSummary ToSummary()
        {
            var _defaultFont = DefaultFont == null ? null : new AlphabetFont(DefaultFont.Description);
            var _alphabet = new AlphabetSummary(ID, FriendlyName, RightToLeft, _defaultFont, KeyboardLayoutID);
            return _alphabet;
        }

        public override string ToString()
        {
            return FriendlyName;
        }

        public XmlAlphabet Clone()
        {
         
            var _clonedFont = DefaultFont == null ? null :
                new XmlFont { Description = DefaultFont.Description };
            return new XmlAlphabet(ID, FriendlyName, RightToLeft, _clonedFont, KeyboardLayoutID);
        }
    }
}
