using System.Collections.Generic;
using System.Linq;

namespace Bitig.Logic.Repository
{
    public static class IDGenerator
    {
        public static int GenerateID(IEnumerable<int> ExistingIDs)
        {
            if (!ExistingIDs.Any())
                return 0;
            return ExistingIDs.Max() + 1;
        }
    }
}
