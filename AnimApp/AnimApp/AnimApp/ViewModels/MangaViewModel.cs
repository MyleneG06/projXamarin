using AnimApp.Models;
using AnimApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static AnimApp.Models.MangasModel;

namespace AnimApp.ViewModels
{
    public class MangaViewModel : BaseViewModel
    {
        public MangaViewModel(Datum MangaSelected)
        {
            Title = $"AniMangApp - MANGA : {MangaSelected.attributes.canonicalTitle} ";
            LoadMangaDetails(MangaSelected);
        }

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
        double mangaRating;
        public double MangaRating
        {
            get { return mangaRating; }
            set { SetProperty(ref mangaRating, value); }
        }
        string mangaRatingImage;
        public string MangaRatingImage
        {
            get { return mangaRatingImage; }
            set { SetProperty(ref mangaRatingImage, value); }
        }
        string mangaTitleTranslation;
        public string MangaTitleTranslation
        {
            get { return mangaTitleTranslation; }
            set { SetProperty(ref mangaTitleTranslation, value); }
        }
        string showNbLike;
        public string ShowNbLike
        {
            get { return showNbLike; }
            set { SetProperty(ref showNbLike, value); }
        }

        public MangasModel.Datum MangaSelected { get; }

        public void LoadMangaDetails(Datum MangaSelected)
        {
            MangaTitle = MangaSelected.attributes.canonicalTitle ?? "Manga title";
            MangaId = Convert.ToInt32(MangaSelected.id);
            MangaCover = MangaSelected.attributes?.coverImage?.original ?? "mangaCover.jpg";
            MangaImage = MangaSelected.attributes?.posterImage?.original ?? "manga.png";
            MangaDate = MangaSelected.attributes?.startDate ?? "unknown date";
            //MangaRating = Convert.ToDouble(MangaSelected.attributes?.averageRating);
            MangaRating = (MangaSelected.attributes?.averageRating != null && MangaSelected.attributes?.averageRating != "") ? Convert.ToDouble(MangaSelected.attributes?.averageRating) : 0;
            if (MangaRating == 0)
            {
                MangaRatingImage = "rating0.png";
            }
            else if (MangaRating > 0 && MangaRating <= 10)
            {
                MangaRatingImage = "rating10.png";
            }
            else if (MangaRating > 10 && MangaRating <= 20)
            {
                MangaRatingImage = "rating20.png";
            }
            else if (MangaRating > 20 && MangaRating <= 30)
            {
                MangaRatingImage = "rating30.png";
            }
            else if (MangaRating > 30 && MangaRating <= 40)
            {
                MangaRatingImage = "rating40.png";
            }
            else if (MangaRating > 40 && MangaRating <= 50)
            {
                MangaRatingImage = "rating50.png";
            }
            else if (MangaRating > 50 && MangaRating <= 60)
            {
                MangaRatingImage = "rating60.png";
            }
            else if (MangaRating > 60 && MangaRating <= 70)
            {
                MangaRatingImage = "rating70.png";
            }
            else if (MangaRating > 70 && MangaRating <= 80)
            {
                MangaRatingImage = "rating80.png";
            }
            else if (MangaRating > 80 && MangaRating <= 90)
            {
                MangaRatingImage = "rating90.png";
            }
            else
            {
                MangaRatingImage = "rating100.png";
            }
            MangaDescription = MangaSelected.attributes?.description.ToString() ?? "unknown description";
            MangaTitleTranslation = MangaSelected.attributes?.titles?.ja_jp ?? "no traduction available";
            
            prefNameLikes += MangaTitle;
            nbLikes = Preferences.Get(prefNameLikes, 0);
            ShowNbLike = nbLikes.ToString();
        }

        public ICommand ToastTranslateCommand => new Command(ToastTranslate);
        private void ToastTranslate(object obj)
        {
            DependencyService.Get<IToastTranslateService>()?.DisplayTranslate(MangaTitleTranslation);
        }

        public ICommand LikeCommand => new Command(ClickToLike);

        int nbLikes = 0;
        string prefNameLikes = "nbLikesManga";


        void ClickToLike()
        {
            nbLikes++;
            ShowNbLike = nbLikes.ToString();
            Preferences.Set(prefNameLikes, nbLikes);
        }
    }

}
