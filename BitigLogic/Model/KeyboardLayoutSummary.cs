using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class KeyboardLayoutSummary : EquatableByID<int>
    {
        public override int ID { get; set; }
        public string FriendlyName { get; set; }

        public override string ToString()
        {
            return FriendlyName;
        }
    }
}
