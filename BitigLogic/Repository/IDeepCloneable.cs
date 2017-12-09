namespace Bitig.Logic.Repository
{
    public interface IDeepCloneable<T>
    {
        T Clone();
    }
}
