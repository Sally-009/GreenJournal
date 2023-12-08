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
        public DiaryDetailPage()
        {
            InitializeComponent();

            BindingContext = new DiaryDetailVM();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (BindingContext is DiaryDetailVM viewModel)
            {
                await viewModel.OnDeleteClickedAsync();
            }
        }

    }

}