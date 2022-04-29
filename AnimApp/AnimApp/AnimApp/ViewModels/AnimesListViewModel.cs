using AnimApp.Models;
using AnimApp.Services;
using AnimApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static AnimApp.Models.AnimesModel;

namespace AnimApp.ViewModels
{
    class AnimesListViewModel : BaseViewModel
    {
        public AnimesListViewModel()
        {
            Title = "AniMangApp : liste des animés";
            LoadAnimesList(); // HTTP request : json format deserialisé en AnimesList
        }

        List<Datum> animesList;
        public List<Datum> AnimesList
        {
            get { return animesList; }
            set { SetProperty(ref animesList, value); }
        }

        Datum animeSelected;
        public Datum AnimeSelected
        {
            get { return animeSelected; }
            set
            {
                SetProperty(ref animeSelected, value);
                if (value != null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new AnimePage(AnimeSelected)); 
                        animeSelected = null;
                    });
                }
            }
        }

        public ICommand GetAnimesList => new Command(() => Task.Run(LoadAnimesList));
        async Task LoadAnimesList()
        {   
            var client = HttpService.GetInstance();
            var result = await client.GetAsync($"https://kitsu.io/api/edge/anime");
            var stringifiedAnswer = await result.Content.ReadAsStringAsync();
            var animeDetailResponse = JsonConvert.DeserializeObject<AnimesModel.Root>(stringifiedAnswer);
            AnimesList = animeDetailResponse.data; // Resources are paginated in groups of 10 by default and can be increased to a maximum of 20.
        }

        //PAGINATION
        //supported via limit and offset :      /anime?page[limit]=5&page[offset]=0
        //The response will include URLs for the first, next and last page of resources in the links object based on your request.
        //    "links": {
                //"first": "https://kitsu.io/api/edge/anime?page[limit]=5&page[offset]=0",
                //"next": "https://kitsu.io/api/edge/anime?page[limit]=5&page[offset]=5",
                //"last": "https://kitsu.io/api/edge/anime?page[limit]=5&page[offset]=12062"
                //}
}

}
