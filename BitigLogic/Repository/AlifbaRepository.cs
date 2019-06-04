using System.Collections.Generic;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class AlifbaRepository
    {
        public abstract IDataContext DataContext { get; }

        public abstract List<AlifbaSummary> GetList();

        public abstract Alifba Get(int ID);

        public abstract void Insert(AlifbaSummary Item);

        public abstract void Delete(int ID);

        public abstract void Update(AlifbaSummary Item);

        public abstract Alifba GetYanalif();
    }
}
