using GreenJournal.Models;
using GreenJournal.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenJournal
{
    public partial class App : Application
    {
        // Setup Database
        private static JournalsDB database;

        public static JournalsDB Database
        {

            get
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "journal.db3");

                if (database == null)
                {
                    database = new
                        JournalsDB(dbPath);
                }

                return database;
            }
        }

        // Operation when lounched
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            //#if DEBUG
            //App.Database.DeleteAllData().Wait();
            //#endif
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
