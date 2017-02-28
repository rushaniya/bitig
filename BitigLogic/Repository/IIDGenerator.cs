using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Repository
{
    public interface IIDGenerator<T, IDType>
    {
        IDType GenerateID(List<T> List);
        IDType DefaultID { get; }
    }
}
