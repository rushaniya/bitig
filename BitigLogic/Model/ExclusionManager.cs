using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Model
{
    public static class ExclusionManager
    {
        private static List<Exclusion> exclusions;

        public static List<Exclusion> Exclusions
        {
            get
            {
                if (exclusions == null) FillExclusions();
                return exclusions;
            }
        }

        private static bool reloadExclusions = false;

        public static bool ReloadExclusions
        {
            get { return reloadExclusions; }
            set { reloadExclusions = value; }
        }

        //repo
        private static void FillExclusions()
        {
            throw new NotImplementedException();
            //exclusions = ExclusionSerializer.ReadFromFile();
        }

        public static List<Exclusion> GetExclusions(int DirectionID)
        {
            if (exclusions == null) FillExclusions();
            return exclusions.Where(_excl => _excl.DirectionID == DirectionID).ToList();
        }

        //excl:needed?
        public static List<string> ExlusionSourceWords(int DirectionID)
        {
            List<string> _result = new List<string>();
            if (exclusions == null) FillExclusions();
            var _query = exclusions.Where(_excl => _excl.DirectionID == DirectionID).Select(_excl => _excl.SourceWord);
            _result = _query.ToList();
            return _result;
        }
    }
}
