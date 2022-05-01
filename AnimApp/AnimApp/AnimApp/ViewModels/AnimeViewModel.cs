using AnimApp.Services;
using AnimApp.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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

        // Variable bindée pour le titre de l'anime.
        string animeTitle;
        public string AnimeTitle
        {
            get { return animeTitle; }
            set { SetProperty(ref animeTitle, value); }
        }

        // Variable bindée pour l'id de l'anime.
        int animeId;
        public int AnimeId
        {
            get { return animeId; }
            set { SetProperty(ref animeId, value); }
        }

        // Variable bindée pour la photo de background de l'anime.
        string animeCover;
        public string AnimeCover
        {
            get { return animeCover; }
            set { SetProperty(ref animeCover, value); }
        }

        // Variable bindée pour la photo de l'anime.
        string animeImage;
        public string AnimeImage
        {
            get { return animeImage; }
            set { SetProperty(ref animeImage, value); }
        }

        // Variable bindée pour le synopsis de l'anime.
        string animeDescription;
        public string AnimeDescription
        {
            get { return animeDescription; }
            set { SetProperty(ref animeDescription, value); }
        }

        // Variable bindée pour la date de sortie de l'anime.
        string animeDate;
        public string AnimeDate
        {
            get { return animeDate; }
            set { SetProperty(ref animeDate, value); }
        }

        // Variable bindée pour le rating de l'anime.
        double animeRating;
        public double AnimeRating
        {
            get { return animeRating; }
            set { SetProperty(ref animeRating, value); }
        }

        // Variable bindée pour l'image du rating (étoiles) de l'anime.
        string animeRatingImage;
        public string AnimeRatingImage
        {
            get { return animeRatingImage; }
            set { SetProperty(ref animeRatingImage, value); }
        }

        // Variable bindée pour le nombre de likes de l'anime.
        string showNbLike;
        public string ShowNbLike
        {
            get { return showNbLike; }
            set { SetProperty(ref showNbLike, value); }
        }

        // Variable bindée pour la traduction en japonais du titre de l'anime.
        string animeTitleTranslation;
        public string AnimeTitleTranslation
        {
            get { return animeTitleTranslation; }
            set { SetProperty(ref animeTitleTranslation, value); }
        }

        // Variable bindée de l'id de la vidéo du trailer de l'anime.
        string animeTrailerId;
        public string AnimeTrailerId
        {
            get { return animeTrailerId; }
            set { SetProperty(ref animeTrailerId, value); }
        }

        // Fonction d'attribution des informations récupérées via l'API dans les variables bindées à la page XML.
        public void LoadAnimeDetails(Datum AnimeSelected)
        {
            AnimeTitle = AnimeSelected.attributes.canonicalTitle ?? "Anime title";
            AnimeTitleTranslation = AnimeSelected.attributes?.titles?.ja_jp ?? "no traduction available";
            AnimeId = Convert.ToInt32(AnimeSelected.id);
            AnimeCover = AnimeSelected.attributes?.coverImage?.original ?? "animeCover.jpg";
            AnimeImage = AnimeSelected.attributes?.posterImage?.original ?? "anime.png";
            AnimeDate = AnimeSelected.attributes?.startDate ?? "unknown date";
            AnimeTrailerId = AnimeSelected.attributes.youtubeVideoId;
            AnimeRating = (AnimeSelected.attributes?.averageRating != null && AnimeSelected.attributes?.averageRating != "") ? Convert.ToDouble(AnimeSelected.attributes?.averageRating) : 0;
            getRatingImage(AnimeRating); //algo rating
            AnimeDescription = AnimeSelected.attributes?.description.ToString() ?? "unknown description";
            
            prefNameLikes += AnimeTitle;
            nbLikes = Preferences.Get(prefNameLikes, 0);
            ShowNbLike = nbLikes.ToString();
        }

        // Fonction de sélection de l'image du rating en fonction du rating (0-100) récupéré via l'API.
        private void getRatingImage(double AnimeRating)
        {
            if (AnimeRating == 0)
            {
                AnimeRatingImage = "rating0.png";
            }
            else if (AnimeRating > 0 && AnimeRating <= 10)
            {
                AnimeRatingImage = "rating10.png";
            }
            else if (AnimeRating > 10 && AnimeRating <= 20)
            {
                AnimeRatingImage = "rating20.png";
            }
            else if (AnimeRating > 20 && AnimeRating <= 30)
            {
                AnimeRatingImage = "rating30.png";
            }
            else if (AnimeRating > 30 && AnimeRating <= 40)
            {
                AnimeRatingImage = "rating40.png";
            }
            else if (AnimeRating > 40 && AnimeRating <= 50)
            {
                AnimeRatingImage = "rating50.png";
            }
            else if (AnimeRating > 50 && AnimeRating <= 60)
            {
                AnimeRatingImage = "rating60.png";
            }
            else if (AnimeRating > 60 && AnimeRating <= 70)
            {
                AnimeRatingImage = "rating70.png";
            }
            else if (AnimeRating > 70 && AnimeRating <= 80)
            {
                AnimeRatingImage = "rating80.png";
            }
            else if (AnimeRating > 80 && AnimeRating <= 90)
            {
                AnimeRatingImage = "rating90.png";
            }
            else
            {
                AnimeRatingImage = "rating100.png";
            }
        }

        // Commande bindée pour afficher une pop-up avec la traduction en japonais du titre de l'anime.
        public ICommand ToastTranslateCommand => new Command(ToastTranslate);
        private void ToastTranslate(object obj)
        {
            DependencyService.Get<IToastTranslateService>()?.DisplayTranslate(AnimeTitleTranslation);
        }

        // Commande bindée pour ouvrir la pop-up de la vidéo du trailer de l'anime.
        public ICommand OpenPopup => new Command(OpenVideo);

        private void OpenVideo()
        {
            if(AnimeTrailerId != "")
            {
                Application.Current.MainPage.Navigation.PushPopupAsync(new PopPup(AnimeTrailerId));
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "La vidéo n'est pas disponible pour le moment.", "Retour");

            }
                
        }

        // Commande bindée pour ajouter un like à la page d'anime lors du clique sur le bouton de like.
        public ICommand LikeCommand => new Command(ClickToLike);
        int nbLikes = 0;
        string prefNameLikes = "nbLikesAnime";
        void ClickToLike()
        {
            nbLikes++;
            ShowNbLike = nbLikes.ToString();
            Preferences.Set(prefNameLikes, nbLikes);
        }
    }


}

