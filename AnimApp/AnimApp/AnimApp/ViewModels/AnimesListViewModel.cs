using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.ViewModels
{
    class AnimesListViewModel : BaseViewModel
    {
        public AnimesListViewModel()
        {
            Title = "AniMangApp : liste des animés";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }
    }

}
