using GreenJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GreenJournal.ViewModels
{
    public class TopPageVM : BaseViewModel
    {
        private Journals _randomJournal;
        
        // Property Interface
        public Journals RandomJournal
        {
            get { return _randomJournal; }
            set
            {
                if (_randomJournal != value)
                {
                    _randomJournal = value;
                    OnPropertyChanged(nameof(RandomJournal));
                }
            }
        }
        public TopPageVM()
        {
            LoadRandomJournal();
        }

        public void OnAppearing()
        {
            LoadRandomJournal();
        }

        // Get random ID and show the page
        public async void LoadRandomJournal()
        {
            // get the random number
            int maxNum = await App.Database.GetMaxJournalIDAsync();

            if (maxNum > 0)
            {
                while (true)
                {
                    Random random = new Random();
                    int num = random.Next(1, maxNum + 1);

                    // assign journal
                    RandomJournal = await App.Database.GetJournalByIDAsync(num);

                    // check if the journal exists
                    if (RandomJournal != null)
                    {
                        break;
                        // Exit the loop
                    }

                    // if the journal does not exist, decide num again

                }
            }




        }
    }
}