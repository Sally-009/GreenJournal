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

            // Bind to VM file
            BindingContext = new DiaryListViewVM();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Load the database
            List<Journals> journals = await App.Database.GetJournalsAsync();

            // Sort the list by date
            journals.Sort((journal1, journal2) => journal1.Date.CompareTo(journal2.Date));

            // Set the sorted list as the ItemsSource
            ListView.ItemsSource = journals;
        }
    }
}