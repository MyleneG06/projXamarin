using AnimApp.Services;
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
    public class AnimeViewModel : BaseViewModel
    {
        public AnimeViewModel(Datum AnimeSelected)
        {
            Title = $"AniMangApp - ANIME : {AnimeSelected.attributes.canonicalTitle} ";
            //AnimeId = Convert.ToInt32(AnimeSelected.id);
            //AnimeTitle = AnimeSelected.attributes.canonicalTitle;
            //AnimeDescription = AnimeSelected.attributes.description;
            LoadAnimeDetails(AnimeSelected);
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

        string animeCover;
        public string AnimeCover
        {
            get { return animeCover; }
            set { SetProperty(ref animeCover, value); }
        }
        string animeImage;
        public string AnimeImage
        {
            get { return animeImage; }
            set { SetProperty(ref animeImage, value); }
        }
        string animeDescription;
        public string AnimeDescription
        {
            get { return animeDescription; }
            set { SetProperty(ref animeDescription, value); }
        }
        string animeDate;
        public string AnimeDate
        {
            get { return animeDate; }
            set { SetProperty(ref animeDate, value); }
        }
        //string animeEndDate;
        //public string AnimeEndDate
        //{
        //    get { return animeEndDate; }
        //    set { SetProperty(ref animeEndDate, value); }
        //}
        double animeRating;
        public double AnimeRating
        {
            get { return animeRating; }
            set { SetProperty(ref animeRating, value); }
        }

        string animeTitleTranslation;
        public string AnimeTitleTranslation
        {
            get { return animeTitleTranslation; }
            set { SetProperty(ref animeTitleTranslation, value); }
        }


        //public ICommand GetAnimeDetails => new Command(() => Task.Run(LoadAnimeDetails));
        //async Task LoadAnimeDetails(Datum AnimeSelected)
        public void LoadAnimeDetails(Datum AnimeSelected)
        {
            AnimeTitle = AnimeSelected.attributes.canonicalTitle ?? "Manga title";
            AnimeId = Convert.ToInt32(AnimeSelected.id);
            AnimeCover = AnimeSelected.attributes?.coverImage?.original ?? "animeCover.jpg";
            AnimeImage = AnimeSelected.attributes?.posterImage?.original ?? "anime.jpg";
            //MangaViews = 
            //MangaLikes = 
            AnimeDate = AnimeSelected.attributes?.startDate ?? "unknown date";
            //MangaEndDate = mangaDetail.attributes.endDate;
            AnimeRating = Convert.ToDouble(AnimeSelected.attributes?.averageRating);
            AnimeDescription = AnimeSelected.attributes?.description.ToString() ?? "unknown description";
            AnimeTitleTranslation = AnimeSelected.attributes?.titles?.ja_jp ?? "no traduction available";
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

