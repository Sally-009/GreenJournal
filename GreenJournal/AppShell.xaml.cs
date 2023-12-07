using GreenJournal.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GreenJournal
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("DiaryDetailPage", typeof(DiaryDetailPage));
        }

    }
}
