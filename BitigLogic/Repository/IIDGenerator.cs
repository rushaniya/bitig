using System.Collections.Generic;

namespace Bitig.Logic.Repository
{
    //repo: delete?
    public interface IIDGenerator<T, IDType>
    {
        IDType GenerateID(List<T> List);
        IDType DefaultID { get; }
    }
}
