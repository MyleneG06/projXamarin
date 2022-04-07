using AnimApp.Models;
using AnimApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AnimApp.ViewModels
{
    class MangasListViewModel : BaseViewModel
    {
        public MangasListViewModel()
        {
            Title = "AniMangApp : liste des mangas";
        }

        string mangasList;
        public string MangasList
        {
            get { return mangasList; }
            set { SetProperty(ref mangasList, value); }
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

        string mangaDate;
        public string MangaDate
        {
            get { return mangaDate; }
            set { SetProperty(ref mangaDate, value); }
        }

        public ICommand GetMangasList => new Command(() => Task.Run(LoadMangasList));
        async Task LoadMangasList()
        {
            var client = HttpService.GetInstance();
            var result = await client.GetAsync($"https://kitsu.io/api/edge/manga?");
            var stringifiedAnswer = await result.Content.ReadAsStringAsync();
            var mangaDetailResponse = JsonConvert.DeserializeObject<MangasModel.Root>(stringifiedAnswer);

            MangasList = mangaDetailResponse.data.ToString();
            //MangaTitle = mangaDetail.attributes.canonicalTitle ?? "Titre du Manga";
            //MangaId = Convert.ToInt32(mangaDetail.id);
            //MangaDate = mangaDetail.attributes.startDate;

        }
    }
}
