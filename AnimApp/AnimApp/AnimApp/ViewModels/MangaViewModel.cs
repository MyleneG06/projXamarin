using AnimApp.Models;
using AnimApp.Services;
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
        string mangaTitleTranslation;
        public string MangaTitleTranslation
        {
            get { return mangaTitleTranslation; }
            set { SetProperty(ref mangaTitleTranslation, value); }
        }

        public MangasModel.Datum MangaSelected { get; }

        public void LoadMangaDetails(Datum MangaSelected)
        {
            MangaTitle = MangaSelected.attributes.canonicalTitle ?? "Manga title";
            MangaId = Convert.ToInt32(MangaSelected.id);
            MangaCover = MangaSelected.attributes?.coverImage?.original ?? "mangaCover.jpg";
            MangaImage = MangaSelected.attributes?.posterImage?.original ?? "manga.png";
            //MangaViews = 
            //MangaLikes = 
            MangaDate = MangaSelected.attributes?.startDate ?? "unknown date";
            MangaRating = Convert.ToDouble(MangaSelected.attributes?.averageRating);
            MangaDescription = MangaSelected.attributes?.description.ToString() ?? "unknown description";
            MangaTitleTranslation = MangaSelected.attributes?.titles?.ja_jp ?? "no traduction available";
        }
    }

}
