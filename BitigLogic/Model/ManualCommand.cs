using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Model
{
    public class ManualCommand
    {
        public Dictionary<AlifbaSymbol, AlifbaSymbol> SymbolMapping { get; private set; }

        public ManualCommand(Dictionary<AlifbaSymbol, AlifbaSymbol> SymbolMapping)
        {
            this.SymbolMapping = SymbolMapping;
        }
    }
}
