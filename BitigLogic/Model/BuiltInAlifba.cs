using System.Collections.Generic;

namespace Bitig.Logic.Model
{
    public class BuiltInAlifba
    {
        public BuiltInAlifbaType ID { get; private set; }
        public string DefaultName { get; private set; }
        public List<AlifbaSymbol> CustomSymbols { get; private set; } 
        public bool RightToLeft { get; private set; } 
        public AlifbaFont DefaultFont { get; private set; } 

        internal BuiltInAlifba(BuiltInAlifbaType ID, string DefaultName, List<AlifbaSymbol> CustomSymbols = null,
            bool RightToLeft = false, AlifbaFont DefaultFont = null)
        {
            this.ID = ID;
            this.DefaultName = DefaultName;
            this.CustomSymbols = CustomSymbols;
            this.RightToLeft = RightToLeft;
            this.DefaultFont = DefaultFont;
        }
    }

    public enum BuiltInAlifbaType
    {
        None,
        Yanalif,
        Cyrillic,
        Zamanalif,
        Rasmalif
    }
}
