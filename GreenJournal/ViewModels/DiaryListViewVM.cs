using GreenJournal.Models;
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

            // Update ItemID propaty
            var diaryDetailVM = new DiaryDetailVM();
            diaryDetailVM.ItemID = journal.Id;

            //Use ID to go to the diary detail
            await Shell.Current.GoToAsync("//DiaryDetailPage");
        }

    }
}