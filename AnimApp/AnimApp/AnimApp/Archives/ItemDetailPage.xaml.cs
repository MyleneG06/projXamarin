using AnimApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnimApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}