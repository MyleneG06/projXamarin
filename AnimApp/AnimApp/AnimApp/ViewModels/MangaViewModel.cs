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
    class MangaViewModel : BaseViewModel
    {
        public MangaViewModel()
        {
            Title = "AniMangApp : détail du manga sélectionné";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }

        // index du manga / animé
        public int index = 0;
        //var result = await client.GetAsync($"https://kitsu.io/api/edge/manga/{index}");

        string mangaTitle;
        public string MangaTitle
        {
            get { return mangaTitle; }
            set { SetProperty(ref mangaTitle, value); }
        }

        int mangaId;
        public int MangaId
        {
            get { return mangaId; }
            set { SetProperty(ref mangaId, value); }
        }

        string mangaCover;
        public string MangaCover
        {
            get { return mangaCover; }
            set { SetProperty(ref mangaCover, value); }
        }
        string mangaImage;
        public string MangaImage
        {
            get { return mangaImage; }
            set { SetProperty(ref mangaImage, value); }
        }
        string mangaDescription;
        public string MangaDescription
        {
            get { return mangaDescription; }
            set { SetProperty(ref mangaDescription, value); }
        }
        string mangaDate;
        public string MangaDate
        {
            get { return mangaDate; }
            set { SetProperty(ref mangaDate, value); }
        }
        //string mangaEndDate;
        //public string MangaEndDate
        //{
        //    get { return mangaEndDate; }
        //    set { SetProperty(ref mangaEndDate, value); }
        //}
        double mangaRating;
        public double MangaRating
        {
            get { return mangaRating; }
            set { SetProperty(ref mangaRating, value); }
        }

        string mangaTitleTranslation;
        public string MangaTitleTranslation
        {
            get { return mangaTitleTranslation; }
            set { SetProperty(ref mangaTitleTranslation, value); }
        }


        public ICommand GetMangasList => new Command(() => Task.Run(LoadMangasList));
        async Task LoadMangasList()
        {
            var client = HttpService.GetInstance();
            var result = await client.GetAsync($"https://kitsu.io/api/edge/manga?");
            var stringifiedAnswer = await result.Content.ReadAsStringAsync();
            var mangaDetailResponse = JsonConvert.DeserializeObject<MangasModel>(stringifiedAnswer);
            var mangaDetail = mangaDetailResponse.data[index];

            MangaTitle = mangaDetail.attributes.canonicalTitle ?? "Titre du Manga";
            MangaId = Convert.ToInt32(mangaDetail.id);
            MangaCover = mangaDetail.attributes.coverImage?.original ?? "mangaCover.jpg";
            MangaImage = mangaDetail.attributes.posterImage.original;
            //MangaViews = 
            //MangaLikes = 
            MangaDate = mangaDetail.attributes.startDate;
            //MangaEndDate = mangaDetail.attributes.endDate;
            MangaRating = Convert.ToDouble(mangaDetail.attributes.averageRating);
            MangaDescription = mangaDetail.attributes.description.ToString();
            MangaTitleTranslation = mangaDetail.attributes.titles.ja_jp ?? "Pas de traduction disponible";
        }

        //    //if (mangaDetailsResponse?.Weather != null && mangaDetailsResponse.Weather.Any())
        //    //{
        //    //    //ErrorMessage = "";
        //    //    MangaDetail = weatherResponse.Name;
        //    //    //WindSpeed = $"{weatherResponse.Wind.Speed} km/h";
        //    //}
        //    //else
        //    //{
        //    //    ErrorMessage = weatherResponse?.Message ?? "Unknown error";
        //    //    //if (weatherResponse == null || weatherResponse.Message == null)
        //    //    //{ ErrorMessage = “Unknown error”; }
        //    //    //else { ErrorMessage = weatherResponse.Message; }

        //        //    City = "unknown";
        //        //    WindSpeed = "unknown";
        //        //    Humidity = "unknown";
        //        //    Visibility = "unknown";
        //        //    Temperature = "unknown";
        //        //}
    }

}
