using GreenJournal.Models;
using System;
using System.Dynamic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenJournal.ViewModels
{
    [QueryProperty(nameof(EditedJournalID), "journalID")]
    public class EditDiaryVM : BaseViewModel
    {
        private Journals _editedJournal;

        public int EditedJournalID
        {
            set
            {
                LoadEditedJournal(value);
            }
        }


        // Property
        public Journals EditedJournal
        {
            get
            {
                return _editedJournal;
            }

            set
            {
                SetProperty(ref _editedJournal, value);
            }
        }

        // Constructor
        public EditDiaryVM()
        {
        }

        // Load the data from ID
        private async void LoadEditedJournal(int id)
        {
            // Load the journal based on the ID
            EditedJournal = await App.Database.GetJournalByIDAsync(id);
        }
    }
}
