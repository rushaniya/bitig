using System.Collections.Generic;

namespace Bitig.Base
{
    public class IgnoreCaseComparer : IEqualityComparer<string>
    {
        private Dictionary<char, char> keyUpperLowerPairs;

        public IgnoreCaseComparer(Dictionary<char, char> UpperLowerPairs)
        {
            keyUpperLowerPairs = UpperLowerPairs;
        }

        #region IEqualityComparer<string> Members

        public bool Equals(string x, string y)
        {
            return TextHelper.EqualsIgnoreCase(x, y, keyUpperLowerPairs);
        }

        public int GetHashCode(string obj)
        {
            var _upper = TextHelper.ToUpper(obj, keyUpperLowerPairs);
            return _upper.GetHashCode();
        }

        #endregion
    }
}
