namespace Bitig.Logic.Repository
{
    public interface IDataContext
    {
        void SaveChanges();
        void CancelChanges();
        bool IsFlushable { get; }
        AlphabetRepository AlphabetRepository { get; }
        DirectionRepository DirectionRepository { get; }
        KeyboardRepository KeyboardRepository { get; }
    }
}
