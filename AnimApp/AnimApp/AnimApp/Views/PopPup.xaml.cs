using AnimApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
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
    public partial class PopPup : Rg.Plugins.Popup.Pages.PopupPage
    {


        private string urlYoutube;
        readonly PopupViewModel pop;
        public PopPup(string id)
        {
            InitializeComponent();
            pop = new PopupViewModel(id);
            BindingContext = pop;
            
        }

        public void ClosePopPup(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        public void PopupPage_BackgroundClicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}