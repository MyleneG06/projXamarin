using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.ViewModels
{
    public class PopupViewModel : BaseViewModel
    {
        const string baseURL = "https://www.youtube.com/embed/";

        string animeTitle;

        public string AnimeTitle
        {
            get { return animeTitle; }
            set { SetProperty(ref animeTitle, value); }
        }

        string animeTrailerId;
        public string AnimeTrailerId
        {
            get { return animeTrailerId; }
            set { SetProperty(ref animeTrailerId, value); }
        }

        public PopupViewModel(string urlId)
        {
            AnimeTrailerId = baseURL + urlId;
        }
    }
}
