using GreenJournal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenJournal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDiaryPage : ContentPage
    {
        public EditDiaryPage()
        {
            InitializeComponent();
            BindingContext = new EditDiaryVM();
        }

        // This is the operation when "save" is clicked
        public async void OnSaveClicked(object sender, EventArgs e)
        {
            // Make sure the entry is not empty
            if (!string.IsNullOrWhiteSpace(TitleEntry.Text) && !string.IsNullOrWhiteSpace(ContentEntry.Text))
            {
                // get the edited data
                var editedJournal = (BindingContext as EditDiaryVM)?.EditedJournal;

                // Update database
                editedJournal.Title = TitleEntry.Text;
                editedJournal.Content = ContentEntry.Text;

                await App.Database.UpdateJournalAsync(editedJournal);

                // Navigate back to the detail page
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}