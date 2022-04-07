using AnimApp.Models;
using AnimApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AnimApp.ViewModels
{
    class AnimesListViewModel : BaseViewModel
    {
        public AnimesListViewModel()
        {
            Title = "AniMangApp : liste des animés";

            //this.AnimesList = animesList;
        }
        //public AnimesListViewModel(string test)
        //{
        //    //Title = "AniMangApp : liste des animés";

        //    this.AnimesList = test;
        //}

        string animesList;
        public string AnimesList
        {
            get { return animesList; }
            set { SetProperty(ref animesList, value); }
        }

        string animeTitle;
        public string AnimeTitle
        {
            get { return animeTitle; }
            set { SetProperty(ref animeTitle, value); }
        }

        int animeId;
        public int AnimeId
        {
            get { return animeId; }
            set { SetProperty(ref animeId, value); }
        }

        string animeDate;
        public string AnimeDate
        {
            get { return animeDate; }
            set { SetProperty(ref animeDate, value); }
        }

        public ICommand GetAnimesList => new Command(() => Task.Run(LoadAnimesList));
        async Task LoadAnimesList()
        {
            var client = HttpService.GetInstance();
            var result = await client.GetAsync($"https://kitsu.io/api/edge/anime");
            var stringifiedAnswer = await result.Content.ReadAsStringAsync();
            var mangaDetailResponse = JsonConvert.DeserializeObject < AnimesModel.Root>(stringifiedAnswer);

            AnimesList = stringifiedAnswer;
            //MangaTitle = mangaDetail.attributes.canonicalTitle ?? "Titre du Manga";
            //MangaId = Convert.ToInt32(mangaDetail.id);
            //MangaDate = mangaDetail.attributes.startDate;
            
            
            //new AnimesListViewModel(AnimesList);


        }
    }

}
