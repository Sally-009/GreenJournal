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
            // Add pages that is not in the Tab Bar
            Routing.RegisterRoute("DiaryDetailPage", typeof(DiaryDetailPage));
            Routing.RegisterRoute("EditDiaryPage", typeof(EditDiaryPage));

        }

    }
}
