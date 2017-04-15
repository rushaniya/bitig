namespace Bitig.Logic.Model
{
    public class BuiltInDirection
    {
        private int id = -1;

        public int ID
        {
            get { return id; }
        }

        public Alifba Source { get; private set; }

        public Alifba Target { get; private set; }

        public string FriendlyName { get; private set; }

        internal BuiltInDirection(int ID, Alifba Source, Alifba Target)
        {
            this.id = ID;
            this.Source = Source;
            this.Target = Target;
            string _source = Source == null ? "(none)" : Source.FriendlyName; //loc
            string _target = Target == null ? "(none)" : Target.FriendlyName;
            FriendlyName = string.Format("Built-in {0} - {1}", _source, _target);
        }

        public override string ToString()
        {
            return FriendlyName;
        }
    }
}
