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

        public void LoadAnimeDetails(Datum AnimeSelected)
        {
            AnimeTitle = AnimeSelected.attributes.canonicalTitle ?? "Anime title";
            AnimeId = Convert.ToInt32(AnimeSelected.id);
            AnimeCover = AnimeSelected.attributes?.coverImage?.original ?? "animeCover.jpg";
            AnimeImage = AnimeSelected.attributes?.posterImage?.original ?? "anime.png";
            //MangaViews = 
            //MangaLikes = 
            AnimeDate = AnimeSelected.attributes?.startDate ?? "unknown date";
            AnimeRating = Convert.ToDouble(AnimeSelected.attributes?.averageRating);
            AnimeDescription = AnimeSelected.attributes?.description.ToString() ?? "unknown description";
            AnimeTitleTranslation = AnimeSelected.attributes?.titles?.ja_jp ?? "no traduction available";
        }
    }


}

