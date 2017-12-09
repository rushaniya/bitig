using System.ComponentModel;
using System.Configuration.Install;


namespace Bitig.UI
{
    [RunInstaller(true)]
    public partial class BitigInstaller : Installer
    {
        public BitigInstaller()
        {
            InitializeComponent();
        }
    }
}
