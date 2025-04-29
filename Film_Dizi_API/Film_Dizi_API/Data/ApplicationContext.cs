using Film_Dizi_API.Models;

namespace Film_Dizi_API.Data
{
    public static class ApplicationContext
    {
        public static List<Films> films { get; set; }  
        static ApplicationContext()
        {
            films = new List<Films>()
            {
                new Films(){Id=1,Title="The Last Black",ReleaseDate=1945},
                new Films(){Id=2,Title="Return Of The GF",ReleaseDate=2005},
                new Films(){Id=3,Title="Elaziz's Birth-Remake",ReleaseDate=2002}
            };
        }
    }
}
