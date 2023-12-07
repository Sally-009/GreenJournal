using GreenJournal.Models;
using GreenJournal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GreenJournal.ViewModels
{
    public class DiaryListViewVM : BaseViewModel
    {
        public Command ItemTapped { get; }

        public DiaryListViewVM()
        {
            // Initialize the ItemTapped command
            ItemTapped = new Command<Journals>(OnItemTapped);
        }

        // Move to Diary Detail Page when clicked
        private async void OnItemTapped(Journals journal)
        {
            if (journal == null)
                return;

            // Get Journal ID from the object
            int journalID = journal.Id;

            // Go to the Detail Page with the ID
            await Shell.Current.GoToAsync($"DiaryDetailPage?jounalID={journalID}");

        }

    }
}