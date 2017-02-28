using System;
using System.Linq;
using System.Windows.Forms;

namespace Bitig.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //MessageBox.Show("Test", "Test bitig");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MessageBox.Show(Logic.DirectionManager.Test());
            frmMainForm _frmMain = new frmMainForm();
            if (args.Count() > 0) _frmMain.X_FilePath = args[0];
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);
            Application.Run(_frmMain);
        }

        static System.Reflection.Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return System.Reflection.Assembly.ReflectionOnlyLoad(args.Name);
        }


        //config: любой спорный вопрос разработчики склонны выносить в настройки, но это в корне неверная позиция — 
        //если создатель программы не может решить как лучше, то уж пользователь точно не будет этот вопрос решать
    }
}
