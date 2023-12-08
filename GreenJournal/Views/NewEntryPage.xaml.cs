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
    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            InitializeComponent();
        }

        // This is the operation when "Submit" is clicked
        public async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Make sure the entry is not empty
            if (!string.IsNullOrWhiteSpace(TitleEntry.Text) && !string.IsNullOrWhiteSpace(ContentEntry.Text))
            {
                // Insert Data
                await App.Database.SaveJournalAsync(new Models.Journals
                {
                    Title = TitleEntry.Text,
                    Date = DateEntry.Date,
                    Content = ContentEntry.Text,
                });

                TitleEntry.Text = ContentEntry.Text = string.Empty;
                DateEntry.Date = DateTime.Now;

                // Update Database
                //collectionView.ItemsSource = await App.Database.GetJournalsAsync();
            }

            // Show message when added the journal
            await Application.Current.MainPage.DisplayAlert("", "New Journal Added Successfully!", "OK");

            // Go back to the previous page
            await Shell.Current.GoToAsync("..");
        }
    }
}