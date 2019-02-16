using Bitig.Base;

namespace Bitig.Logic.Repository
{
    public abstract class KeyboardRepository
    {
        public abstract IDataContext DataContext { get; }

        public abstract KeyboardConfig GetKeyboardConfig(int AlifbaID);
    }
}
