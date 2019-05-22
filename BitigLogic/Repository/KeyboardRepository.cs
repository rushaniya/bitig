using System;
using System.Collections.Generic;
using Bitig.Base;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public abstract class KeyboardRepository
    {
        public abstract IDataContext DataContext { get; }

        public abstract KeyboardLayoutBase Get(int KeyboardID);

        public abstract KeyboardLayoutSummary GetSummary(int KeyboardID);

        public abstract List<KeyboardLayoutSummary> GetSummaryList();

        public abstract void Insert(KeyboardLayoutBase KeyboardConfig);

        public abstract void Update(KeyboardLayoutBase KeyboardConfig);

        public abstract void Delete(int KeyboardID);
    }
}
