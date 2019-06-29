using System.Collections.Generic;
using Bitig.Base;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class AlphabetSummary : EquatableByID<int>
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

        public AlphabetFont DefaultFont
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

        public AlphabetSummary()
        {
        }

        public AlphabetSummary(int ID, string FriendlyName, bool RightToLeft = false, AlphabetFont DefaultFont = null, int? KeyboardLayoutID = null)
        {
            id = ID;
            this.FriendlyName = FriendlyName;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
            this.KeyboardLayoutID = KeyboardLayoutID;
        }

        public override string ToString()
        {
            return FriendlyName;
        }
    }

    public class Alphabet : AlphabetSummary
    {
        public List<AlphabetSymbol> CustomSymbols
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

        public Alphabet(int ID, string FriendlyName, bool RightToLeft = false, AlphabetFont DefaultFont = null, 
            KeyboardLayoutBase KeyboardLayout = null, List<AlphabetSymbol> CustomSymbols = null)
            : base(ID, FriendlyName, RightToLeft, DefaultFont, 
                KeyboardLayout == null ? null : (int?)KeyboardLayout.ID)
        {
            this.CustomSymbols = CustomSymbols ?? new List<AlphabetSymbol>();
            this.KeyboardLayout = KeyboardLayout;
        }

    }
}
