using GreenJournal.Models;
using GreenJournal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

// need to fix something here


namespace GreenJournal.ViewModels
{
    [QueryProperty(nameof(SelectedJournalID), "jounalID")]
    public class DiaryDetailVM : BaseViewModel
    {
        // Get ID from List VIew
        public int SelectedJournalID
        {
            set { LoadJournalDetail(value); }
        }

        private Journals _selectedJournal;

        // use property
        public Journals SelectedJournal
        {
            get { return _selectedJournal; }
            set { SetProperty(ref _selectedJournal, value); }
        }

        // constructor
        public DiaryDetailVM()
        {
        }


        // Load and reflect data to binding data.
        public async void LoadJournalDetail(int journalID)
        {
            //var journal = await App.Database.GetJournalByIDAsync(journalID);

            try
            {
                // Set the BindingContext to the retrieved journal
                SelectedJournal = await App.Database.GetJournalByIDAsync(journalID);
            }
            catch (Exception)
            {
                // Handle the case where the journal is not found
                await Application.Current.MainPage.DisplayAlert("Error", "Journal not found", "OK");
                // Optionally, you can navigate back to the previous page or take any other appropriate action.
                await Shell.Current.GoToAsync("..");
            }
        }

        // Delete Operation
        public async Task OnDeleteClickedAsync()
        {
            // delete teh journal
            await App.Database.DeleteJournalAsync(SelectedJournal.Id);

            // show message
            await Application.Current.MainPage.DisplayAlert(SelectedJournal.Title, "Journal Deleted", "OK");

            // go back to the previous page
            await Shell.Current.GoToAsync("..");
        }
    }
}