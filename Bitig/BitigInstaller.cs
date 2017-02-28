using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


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
