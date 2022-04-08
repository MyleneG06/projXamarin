using System;
using System.Collections.Generic;
using System.Text;
using static AnimApp.Models.AnimesModel;

namespace AnimApp.ViewModels
{
    public class AnimeViewModel : BaseViewModel
    {
        public AnimeViewModel(Datum AnimeSelected)
        {
            Title = $"AniMangApp : détail de l'animé sélectionné ... {AnimeSelected.attributes.canonicalTitle} ";
            //AnimeId = Convert.ToInt32(AnimeSelected.id);
            //AnimeTitle = AnimeSelected.attributes.canonicalTitle;
            //AnimeDescription = AnimeSelected.attributes.description;
        }

        //string animeTitle;
        //public string AnimeTitle
        //{
        //    get { return animeTitle; }
        //    set { SetProperty(ref animeTitle, value); }
        //}

        //int animeId;
        //public int AnimeId
        //{
        //    get { return animeId; }
        //    set { SetProperty(ref animeId, value); }
        //}

        //string animeDescription;
        //public string AnimeDescription
        //{
        //    get { return animeDescription; }
        //    set { SetProperty(ref animeDescription, value); }
        //}


    }

}