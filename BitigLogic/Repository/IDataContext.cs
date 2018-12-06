using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Repository
{
    public interface IDataContext
    {
        void SaveChanges();
        void CancelChanges();
        bool IsFlushable { get; }
        AlifbaRepository AlifbaRepository { get; }
        DirectionRepository DirectionRepository { get; }
    }
}
