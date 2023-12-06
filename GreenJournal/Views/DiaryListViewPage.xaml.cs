using GreenJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenJournal.ViewModels;

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
            BindingContext = new DiaryListViewVM();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Load the database
            ListView.ItemsSource = await App.Database.GetJournalsAsync();
        }
    }
}