using System;
using System.Collections.Generic;
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

        public BuiltInAlifbaType BuiltIn { get; set; }

        [Obsolete("For XML serialization only")]
        public XmlAlifba()
        {
            CustomSymbols = new List<XmlAlifbaSymbol>();
        }

        public XmlAlifba(int ID, string FriendlyName, List<XmlAlifbaSymbol> CustomSymbols = null,
            bool RightToLeft = false, XmlFont DefaultFont = null, BuiltInAlifbaType BuiltIn = BuiltInAlifbaType.None)
        {
            this.ID = ID;
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
            this.CustomSymbols = CustomSymbols ?? new List<XmlAlifbaSymbol>();
            this.BuiltIn = BuiltIn;
        }

        public XmlAlifba(Alifba ModelAlifba)
        {
            var _customSymbols = new List<XmlAlifbaSymbol>();
            if (ModelAlifba.CustomSymbols != null)
            {
                foreach (var _symbol in ModelAlifba.CustomSymbols)
                {
                    _customSymbols.Add(new XmlAlifbaSymbol(_symbol));
                }
            }
            ID = ModelAlifba.ID;
            FriendlyName = ModelAlifba.FriendlyName;
            CustomSymbols = _customSymbols;
            RightToLeft = ModelAlifba.RightToLeft;
            if (ModelAlifba.DefaultFont != null)
                DefaultFont = new XmlFont { Description = ModelAlifba.DefaultFont.Description };
            BuiltIn = ModelAlifba.BuiltIn;
        }

        public Alifba ToModel()
        {
            var _customSymbols = new List<AlifbaSymbol>();
            if (CustomSymbols != null)
            {
                foreach (var _symbol in CustomSymbols)
                {
                    _customSymbols.Add(_symbol.ToModel());
                }
            }
            var _defaultFont = DefaultFont == null ? null : new AlifbaFont(DefaultFont.Description);
            var _alifba = new Alifba(ID, FriendlyName,
                _customSymbols, RightToLeft, _defaultFont, BuiltIn);
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

        public XmlAlifba Clone()
        {
            var _clonedSymbols = new List<XmlAlifbaSymbol>();
            if (CustomSymbols != null)
            {
                foreach (var _symbol in CustomSymbols)
                {
                    _clonedSymbols.Add(_symbol.Clone());
                }
            }
            var _clonedFont = DefaultFont == null ? null :
                new XmlFont { Description = DefaultFont.Description };
            return new XmlAlifba(ID, FriendlyName, _clonedSymbols, RightToLeft, _clonedFont, BuiltIn);
        }
    }
}
