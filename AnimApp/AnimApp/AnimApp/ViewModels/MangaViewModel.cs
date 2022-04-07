using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.ViewModels
{
    class MangaViewModel : BaseViewModel
    {
        public MangaViewModel()
        {
            Title = "ANI'MANG'APP : Détail du Manga sélectionné";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }

    }
}
