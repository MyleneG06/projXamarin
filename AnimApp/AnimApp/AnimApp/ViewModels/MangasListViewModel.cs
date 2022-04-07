using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.ViewModels
{
    class MangasListViewModel : BaseViewModel
    {
        public MangasListViewModel()
        {
            Title = "ANI'MANG'APP : Liste des Mangas";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }
    }
}
