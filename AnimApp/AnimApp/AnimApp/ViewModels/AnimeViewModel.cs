using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.ViewModels
{
    class AnimeViewModel : BaseViewModel
    {
        public AnimeViewModel()
        {
            Title = "ANI'MANG'APP : Détail de l'Animé sélectionné";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }
    }

}