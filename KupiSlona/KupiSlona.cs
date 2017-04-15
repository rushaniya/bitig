using Bitig.Base;

namespace KupiSlona
{
    public class KupiSlona : TranslitCommand
    {
        public override string Convert(string Text)
        {
            return string.Format("Все говорят {0}, а ты купи слона", Text);
        }
    }
}
