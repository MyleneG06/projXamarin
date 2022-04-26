using AnimApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
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
            nbViews = Preferences.Get(prefNameViews, 0);
        }

        int nbViews = 0;
        string prefNameViews = "nbViewsAnime";

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