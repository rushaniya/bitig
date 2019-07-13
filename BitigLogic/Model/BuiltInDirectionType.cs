using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class BuiltInDirection
    {
        public BuiltInDirectionType Type
        {
            get; private set;
        }

        public BuiltInAlphabetType Source { get; private set; }

        public BuiltInAlphabetType Target { get; private set; }

        public string FriendlyName { get; private set; }

        internal BuiltInDirection(BuiltInDirectionType ID, BuiltInAlphabetType Source, BuiltInAlphabetType Target)
        {
            this.Type = ID;
            this.Source = Source;
            this.Target = Target;
            FriendlyName = string.Format("Built-in {0} - {1}", //loc
                BuiltInTransliteration.GetAlphabetName(Source), BuiltInTransliteration.GetAlphabetName(Target));
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
