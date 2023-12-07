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
    public partial class DiaryDetailPage : ContentPage
    {
        // Get ID from List VIew
        //public int selectedJournalID
        //{
        //    set { LoadJournalDetail(value); }
        //}

        public DiaryDetailPage()
        {
            InitializeComponent();

            BindingContext = new DiaryDetailVM();
        }

        //// Load and reflect data to binding data.
        //public async void LoadJournalDetail(int jounalID)
        //{
        //    var journal = await App.Database.GetJournalByIDAsync(jounalID);

        //    try
        //    {
        //        // Set the BindingContext to the retrieved journal
        //        BindingContext = journal;
        //    }
        //    catch (Exception)
        //    {
        //        // Handle the case where the journal is not found
        //        await Application.Current.MainPage.DisplayAlert("Error", "Journal not found", "OK");
        //        // Optionally, you can navigate back to the previous page or take any other appropriate action.
        //        await Shell.Current.GoToAsync("..");
        //    }
        //}
    }

}