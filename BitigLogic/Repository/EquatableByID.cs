namespace Bitig.Logic.Repository
{
    public abstract class EquatableByID<IDType> : IRepositoryItem<IDType>
    {
        public abstract IDType ID { get; set; }
        public override bool Equals(object obj)
        {
            var cast=obj as EquatableByID<IDType>;
            if (cast == null)
                return false;
            if(cast.GetType() != this.GetType())
                return false;
            return cast.ID.Equals(this.ID);
        }
    }
}
