using System;
using System.Collections.Generic;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class DirectionRepository 
    {
        public abstract IDataContext DataContext { get; }

        public abstract List<Direction> GetList();

        public abstract Direction Get(int ID);

        public abstract void Insert(Direction Item);

        public abstract void Delete(int ID);

        public abstract void Update(Direction Item);

        public abstract Direction GetByAlphabetIDs(int SourceID, int TargetID);

        public abstract List<AlphabetSummary> GetTargets(int SourceID);

        public abstract Dictionary<TextSymbol, TextSymbol> GetSymbolMapping(int ID);
    }
}
