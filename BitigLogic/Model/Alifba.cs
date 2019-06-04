using System.Collections.Generic;
using Bitig.Base;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class AlifbaSummary : EquatableByID<int>
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

        public BuiltInAlifbaType BuiltIn { get; set; }

        public string FriendlyName
        {
            get;
            set;
        }

        public bool IsYanalif
        {
            get { return BuiltIn == BuiltInAlifbaType.Yanalif; }
        }

        public AlifbaFont DefaultFont
        {
            get;
            set;
        }

        public int? KeyboardLayoutID { get; protected set; }

        public bool RightToLeft
        {
            get;
            set;
        }

        public AlifbaSummary()
        {
        }

        public AlifbaSummary(int ID, string FriendlyName, 
            bool RightToLeft = false, AlifbaFont DefaultFont = null, BuiltInAlifbaType BuiltIn = BuiltInAlifbaType.None,
            int? KeyboardLayoutID = null)
        {
            id = ID;
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
            this.BuiltIn = BuiltIn;
            this.KeyboardLayoutID = KeyboardLayoutID;
        }

        public override string ToString()
        {
            return FriendlyName;
        }
    }

    public class Alifba : AlifbaSummary
    {
        public List<AlifbaSymbol> CustomSymbols
        {
            get;
            set;
        }

        protected KeyboardLayoutBase _keyboardLayout;

        public KeyboardLayoutBase KeyboardLayout
        {
            get { return _keyboardLayout; }
            set
            {
                _keyboardLayout = value;
                KeyboardLayoutID = value == null ? null : (int?)value.ID;
            }
        }

        public Alifba(int ID, string FriendlyName,
            bool RightToLeft = false, AlifbaFont DefaultFont = null, BuiltInAlifbaType BuiltIn = BuiltInAlifbaType.None,
            KeyboardLayoutBase KeyboardLayout = null, List<AlifbaSymbol> CustomSymbols = null)
            : base(ID, FriendlyName, RightToLeft, DefaultFont, BuiltIn,
                KeyboardLayout == null ? null : (int?)KeyboardLayout.ID)
        {
            this.CustomSymbols = CustomSymbols ?? new List<AlifbaSymbol>();
            this.KeyboardLayout = KeyboardLayout;
        }

    }
}
