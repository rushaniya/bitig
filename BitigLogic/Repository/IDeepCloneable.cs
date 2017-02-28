using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Repository
{
    public interface IDeepCloneable<T>
    {
        T Clone();
    }
}
