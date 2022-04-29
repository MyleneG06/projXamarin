using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.ViewModels
{
    class TestViewModel : BaseViewModel
    {
        public TestViewModel()
        {
            Title = "ANI'MANG'APP : Test";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        //public ICommand OpenWebCommand { get; }
    }
}
