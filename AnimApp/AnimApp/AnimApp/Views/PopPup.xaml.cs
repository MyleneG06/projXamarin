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
        public PopPup()
        {
            InitializeComponent();
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