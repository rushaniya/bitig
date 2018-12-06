using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class AlifbaRepository
    {
        public abstract IDataContext DataContext { get; }

        public abstract List<Alifba> GetList();

        public abstract Alifba Get(int ID);

        public abstract Alifba GetBuiltIn(BuiltInAlifbaType BuiltIn);

        public abstract void Insert(Alifba Item);

        public abstract void Delete(int ID);

        public abstract void Update(Alifba Item);

        public abstract Alifba GetYanalif();
    }
}
