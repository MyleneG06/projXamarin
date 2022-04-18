using AnimApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimePage : ContentPage
    {
        public AnimePage(Models.AnimesModel.Datum animeSelected)
        {
            InitializeComponent();
            BindingContext = new AnimeViewModel(animeSelected);
            prefNameViews += animeTitle.Text;
            prefNameLikes += animeTitle.Text;
            nbViews = Preferences.Get(prefNameViews, 0);
            nbLikes = Preferences.Get(prefNameLikes, 0);
            likes.Text = nbLikes.ToString();
        }

        int nbViews = 0;
        int nbLikes = 0;
        string prefNameViews = "nbViewsAnime";
        string prefNameLikes = "nbLikesAnime";

        void Click_To_Like(object sender, EventArgs e)
        {
            nbLikes++;
            likes.Text = nbLikes.ToString();
            Preferences.Set(prefNameLikes, nbLikes);
        }

        protected override void OnAppearing()
        {
            nbViews++;
            views.Text = nbViews.ToString();
            Preferences.Set(prefNameViews, nbViews);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}