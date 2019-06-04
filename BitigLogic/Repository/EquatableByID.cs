namespace Bitig.Logic.Repository
{
    public abstract class EquatableByID<IDType> : IRepositoryItem<IDType>
    {
        public abstract IDType ID { get; set; }
        public override bool Equals(object obj)
        {
            var cast = obj as EquatableByID<IDType>;
            if (cast == null)
                return false;

            var thisType = this.GetType();
            var castType = cast.GetType();
            if (!thisType.IsAssignableFrom(castType) && !castType.IsAssignableFrom(thisType))
                return false;

            return cast.ID.Equals(this.ID);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
