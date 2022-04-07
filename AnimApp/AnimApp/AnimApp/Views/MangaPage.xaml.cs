using AnimApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MangaPage : ContentPage
    {
        public MangaPage()
        {
            InitializeComponent();
            BindingContext = new MangaViewModel();
        }
    }
}