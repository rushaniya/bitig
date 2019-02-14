using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Model
{
    public class ManualCommand
    {
        public Dictionary<TextSymbol, TextSymbol> SymbolMapping { get; private set; }

        public ManualCommand(Dictionary<TextSymbol, TextSymbol> SymbolMapping)
        {
            this.SymbolMapping = SymbolMapping;
        }
    }
}
