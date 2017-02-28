using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Bitig.Data.Storage;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlAlifba
    {
        private int id = -1;

        public int ID
        {
            get { return id; }
            set
            {
                if (AlifbaSerializer.Deserializing)
                    id = value;
            }
        }

        public string FriendlyName
        {
            get;
            set;
        }

        public List<XmlAlifbaSymbol> CustomSymbols
        {
            get;
            set;
        }

        public string KeyboardLayoutID
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

        public XmlAlifba()
        {
            if (!AlifbaSerializer.Deserializing)
                throw new InvalidOperationException("XmlAlifba instances cannot be created with default constructor.");
            CustomSymbols = new List<XmlAlifbaSymbol>();
        }

        internal XmlAlifba(int ID, string FriendlyName, List<XmlAlifbaSymbol> CustomSymbols = null,
            bool RightToLeft = false, XmlFont DefaultFont = null)
        {
            id = ID;
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
            this.CustomSymbols = CustomSymbols ?? new List<XmlAlifbaSymbol>();
        }

        public override string ToString()
        {
            return FriendlyName;
        }

        public override bool Equals(object obj)
        {
            XmlAlifba _cast = obj as XmlAlifba;
            if (_cast == null) return false;
            return _cast.id == this.id;
        }
    }
}
