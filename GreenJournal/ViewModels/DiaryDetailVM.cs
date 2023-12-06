using GreenJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GreenJournal.ViewModels
{
    public class DiaryDetailVM : BaseViewModel
    {
        private int itemID;

        public DiaryDetailVM()
        {
            //LoadJournalDetail(2);
        }

        public int ItemID
        {
            get
            {
                return itemID;
            }
            set
            {
                itemID = value;
                LoadJournalDetail(itemID);
            }
        }

        // This function works fine
        // NEED FIX
        private async void LoadJournalDetail(int jounalID)
        {
            var journal = await App.Database.GetJournalByIDAsync(jounalID);

            if (journal != null)
            {
                // Set the BindingContext to the retrieved journal
                //HERE
                
            }
            else
            {
                // Handle the case where the journal is not found
                await Application.Current.MainPage.DisplayAlert("Error", "Journal not found", "OK");
                // Optionally, you can navigate back to the previous page or take any other appropriate action.
                await Shell.Current.GoToAsync("..");

            }
        }
    }
}