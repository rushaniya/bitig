using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlExclusionCollection : EquatableByID<int>, IDeepCloneable<XmlExclusionCollection>
    {
        public override int ID { get; set; }

        public List<XmlExclusion> Exclusions { get; set; }

        public XmlExclusionCollection Clone()
        {
            return new XmlExclusionCollection { ID = ID, Exclusions = Exclusions.Select(x => x.Clone()).ToList() };
        }

        public XmlExclusionCollection()
        {

        }

        public XmlExclusionCollection(int ID, List<Exclusion> Exclusions)
        {
            this.ID = ID;
            this.Exclusions = Exclusions.Select(x => new XmlExclusion(x)).ToList();
        }
    }
}
