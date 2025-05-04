using Film_Dizi_API.Models;
using Film_Dizi_API.Models.Film_Dizi_API.Models;

namespace Film_Dizi_API.Data
{
    public static class ApplicationContext
    {
        public static List<Series> series { get; set; }
        public static List<Films> films { get; set; }  
        static ApplicationContext()
        {
            films = new List<Films>()
            {
                new Films(){Id=1,Title="The Last Black",ReleaseDate=1945},
                new Films(){Id=2,Title="Return Of The Goerge Floyd",ReleaseDate=2005},
                new Films(){Id=3,Title="Elaziz's Birth-Remake",ReleaseDate=2002}
            };
            series = new List<Series>()
            {
                new Series(){Id=1,Title="Better Call Saul",Publisher="Netflix",Seasons=4},
                new Series(){Id=2,Title="Breaking Bad",Publisher="Netflix",Seasons=5},
                new Series(){Id=3,Title="The Boys",Publisher="PrimeVideo",Seasons=6},
                new Series(){Id=4,Title="Sıfır Bir",Publisher="Digitruk",Seasons=5}
            };
        }
    }
}
