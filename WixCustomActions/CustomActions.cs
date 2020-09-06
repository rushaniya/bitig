using System;
using System.IO;
using Bitig.Data.Storage;
using Bitig.Logic.Repository;
using Microsoft.Deployment.WindowsInstaller;

namespace WixCustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult Seed(Session session)
        {
            var configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bitig");
            var dataContext = new XmlContext(configFolder);
            var seed = new Seed(dataContext);
            seed.Create();
            return ActionResult.Success;
        }
    }
}
