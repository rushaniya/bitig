using System;
using System.IO;
using Microsoft.Deployment.WindowsInstaller;

namespace WixCustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult Seed(Session session)
        {
            File.WriteAllText(@"d:\temp\bitigSetup.txt", DateTime.Now.ToString("s"));

            return ActionResult.Success;
        }
    }
}
