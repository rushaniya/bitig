namespace Bitig.Logic.Model
{
    public class BuiltInDirection
    {
        public BuiltInDirectionType ID
        {
            get; private set;
        }

        public BuiltInAlifbaType Source { get; private set; }

        public BuiltInAlifbaType Target { get; private set; }

        public string FriendlyName { get; private set; }

        internal BuiltInDirection(BuiltInDirectionType ID, BuiltInAlifba Source, BuiltInAlifba Target)
        {
            this.ID = ID;
            this.Source = Source.ID;
            this.Target = Target.ID;
            FriendlyName = string.Format("Built-in {0} - {1}", Source.DefaultName, Target.DefaultName);
            //repo: what if user has changed default alifba names?
        }

        public override string ToString()
        {
            return FriendlyName;
        }
    }

    public enum BuiltInDirectionType
    {
        None,
        CyrillicYanalif,
        CyrillicZamanalif,
        CyrillicRasmalif,
        YanalifZamanalif,
        YanalifRasmalif,
        ZamanalifYanalif,
        RasmalifYanalif
    }
}
