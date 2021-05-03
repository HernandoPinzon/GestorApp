using Gestor.data;
using Gestor.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestor
{
    public partial class App : Application
    {
        public static DataBaseContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            IniciarDataBase();
            MainPage = new NavigationPage(new PageGestor(0));
        }

        private void IniciarDataBase()
        {
            var carpetaAppPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var databasePath = System.IO.Path.Combine(carpetaAppPath, "Gestor.db3");
            Context = new DataBaseContext(databasePath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
