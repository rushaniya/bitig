using System.Collections.Generic;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class Alifba : EquatableByID<int>, IDeepCloneable<Alifba>
    {
        private int id = -1;

        public override int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public string FriendlyName
        {
            get;
            set;
        }

        public bool IsYanalif
        {
            get { return this.id == DefaultConfiguration.YANALIF; }
        }

        public List<AlifbaSymbol> CustomSymbols
        {
            get;
            set;
        }

        public string KeyboardLayoutID
        {
            get;
            set;
        }

        public AlifbaFont DefaultFont
        {
            get;
            set;
        }

        public bool RightToLeft
        {
            get;
            set;
        }

        public BuiltInAlifba BuiltInAlifba { get; set; }

        public Alifba()
        {
        }

        public Alifba(int ID, string FriendlyName, List<AlifbaSymbol> CustomSymbols = null, bool RightToLeft = false, AlifbaFont DefaultFont = null)
        {
            id = ID;
            this.CustomSymbols = CustomSymbols ?? new List<AlifbaSymbol>();
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
        }

        public override string ToString()
        {
            return FriendlyName;
        }

        //public override bool Equals(object obj)
        //{
        //    Alifba _cast = obj as Alifba;
        //    if (_cast == null) return false;
        //    return _cast.id == this.id;
        //}

        public Alifba Clone()
        {
            var _clonedSymbols = new List<AlifbaSymbol>();
            if (CustomSymbols != null)
            {
                foreach (var _symbol in CustomSymbols)
                {
                    _clonedSymbols.Add(new AlifbaSymbol(_symbol.ActualText, _symbol.DisplayText,
                        _symbol.CapitalizedText, _symbol.CapitalizedDisplayText));
                }
            }
            var _clonedFont = DefaultFont == null ? null :
                new AlifbaFont(DefaultFont.Description);
            return new Alifba(ID, FriendlyName, _clonedSymbols, RightToLeft, _clonedFont);
        }
    }
}
