using System.Collections.Generic;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class Alifba : EquatableByID<int>
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

        public List<AlifbaSymbol> CustomSymbols
        {
            get;
            set;
        }

        public int? KeyboardLayoutID
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

        public Alifba()
        {
        }

        public Alifba(int ID, string FriendlyName, List<AlifbaSymbol> CustomSymbols = null, 
            bool RightToLeft = false, AlifbaFont DefaultFont = null, BuiltInAlifbaType BuiltIn= BuiltInAlifbaType.None,
            int? KeyboardLayoutID = null)
        {
            id = ID;
            this.CustomSymbols = CustomSymbols ?? new List<AlifbaSymbol>();
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
}
