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
using static AnimApp.Models.MangasModel;

namespace AnimApp.ViewModels
{
    class MangasListViewModel : BaseViewModel
    {
        public MangasListViewModel()
        {
            Title = "AniMangApp : liste des mangas";
            LoadMangasList(); // HTTP request : json format deserialisé en MangasList
        }

        List<Datum> mangasList;
        public List<Datum> MangasList
        {
            get { return mangasList; }
            set { SetProperty(ref mangasList, value); }
        }

        Datum mangaSelected;
        public Datum MangaSelected
        {
            get { return mangaSelected; }
            set
            {
                SetProperty(ref mangaSelected, value);
                if (value != null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MangaPage(MangaSelected)); 
                        mangaSelected = null;
                    });
                }
            }
        }

        public ICommand GetMangasList => new Command(() => Task.Run(LoadMangasList));
        async Task LoadMangasList()
        {
            var client = HttpService.GetInstance();
            var result = await client.GetAsync($"https://kitsu.io/api/edge/manga");
            var stringifiedAnswer = await result.Content.ReadAsStringAsync();
            var mangaDetailResponse = JsonConvert.DeserializeObject<MangasModel.Root>(stringifiedAnswer);
            MangasList = mangaDetailResponse.data;// Resources are paginated in groups of 10 by default and can be increased to a maximum of 20.
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
