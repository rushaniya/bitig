using System.Collections.Generic;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class AlphabetRepository
    {
        public abstract IDataContext DataContext { get; }

        public abstract List<AlphabetSummary> GetList();

        public abstract Alphabet Get(int ID);

        public abstract void Insert(AlphabetSummary Item);

        public abstract void Delete(int ID);

        public abstract void Update(AlphabetSummary Item);
    }
}
