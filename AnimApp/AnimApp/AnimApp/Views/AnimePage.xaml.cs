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
            prefNameViews += animeTitle.Text; // Ajout du titre de l'anime au nom de la variable préférence pour sauvegarder le nombre de vues.
            nbViews = Preferences.Get(prefNameViews, 0); // Récupération de la variable préférence si elle existe ou 0 si elle n'existe pas.
        }

        int nbViews = 0;
        string prefNameViews = "nbViewsAnime";

        // Fonction appelée lorsque la page est chargée et permet d'incrémenter le nombre de vues et de sauvegarder ce nombre dans les Préférences.
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