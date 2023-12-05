using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenJournal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiaryListViewPage : ContentPage
    {
        public DiaryListViewPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Read the database
            ListView.ItemsSource = await App.Database.GetJournalsAsync();
        }
    }
}