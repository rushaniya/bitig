namespace Bitig.Logic.Repository
{
    public interface IRepositoryItem<IDType>
    {
        IDType ID { get; set; }
    }
}
