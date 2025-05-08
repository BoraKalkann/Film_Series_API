using Film_Dizi_API.Models;
using Film_Dizi_API.Models.Film_Dizi_API.Models;

namespace Film_Dizi_API.Data
{
    public static class ApplicationContext
    {
        public static List<Series> series { get; set; }
        public static List<Films> films { get; set; }  

        public static List<Actors> actors { get; set; }
        static ApplicationContext()
        {
            films = new List<Films>()
            {
                new Films(){Id=1,Title="The Last Black",ReleaseDate=1945,Genre="Horror",Rating=5},
                new Films(){Id=2,Title="The Last Black 2",ReleaseDate=1945,Genre="Horror",Rating=5},
                new Films(){Id=3,Title="Return Of The Goerge Floyd",ReleaseDate=2005,Genre="Thrill",Rating=3},
                new Films(){Id=4,Title="Elaziz's Birth-Remake",ReleaseDate=2002,Genre="Animation",Rating=5},
                new Films(){Id=5,Title="Elaziz's Birth 2",ReleaseDate=2002,Genre="Animation",Rating=5},
                new Films(){Id=7,Title="Fight Club",ReleaseDate=2000,Genre="Action",Rating=5},
                new Films(){Id=8,Title="AA Emre's OOP ",ReleaseDate=1999,Genre="Thrill",Rating=1},
                new Films(){Id=9,Title="New World",ReleaseDate=1983,Genre="Horror",Rating=3.4},
                new Films(){Id=10,Title="Green Road",ReleaseDate=2001,Genre="Drama",Rating=4.6}
            };
            series = new List<Series>()
            {
                new Series(){Id=1,Title="Better Call Saul",Publisher="Netflix",Seasons=4,Genre="Drama",Rating=4.3},
                new Series(){Id=2,Title="Breaking Bad",Publisher="Netflix",Seasons=5,Genre="Drama",Rating=4.6},
                new Series(){Id=3,Title="The Boys",Publisher="Prime Video",Seasons=6,Genre="Thrill",Rating = 4.2},
                new Series(){Id=4,Title="Sıfır Bir",Publisher="Digiturk",Seasons=5,Genre="Action",Rating=5},
                new Series(){Id=5,Title="Punisher",Publisher="Prime Video",Seasons=3,Genre="Action",Rating=3.9},
                new Series(){Id=6,Title="Mr.Robot",Publisher="Prime Video",Seasons=10,Genre="Drama",Rating=4.1},
                new Series(){Id=7,Title="Yirmi Üç",Publisher="Digiturk",Seasons=10,Genre="Action",Rating=5},
                new Series(){Id=8,Title="Wednesday",Publisher="Netflix",Seasons=2,Genre="Drama",Rating=4.2},
                new Series(){Id=9,Title="Walking Dead",Publisher="Netflix",Seasons=6,Genre="Action",Rating = 3.9},
                new Series(){Id=10,Title="Teen Wolf",Publisher="Digiturk",Seasons=3,Genre="Dramam",Rating = 2.1}
            };
            actors = new List<Actors>()
            {
                new Actors(){Id=1,Name="Elaziz",Surname="Kaya",BirthDate=new DateTime(1999,10,10),BirthPlace="Turkey"},
                new Actors(){Id=2,Name="Samet",Surname="Kaya",BirthDate=new DateTime(1978,02,11),BirthPlace="Turkey"},
                new Actors(){Id=3,Name="Emre",Surname="Gürbüz",BirthDate=new DateTime(1966,02,03),BirthPlace="Turkey"},
                new Actors(){Id=4,Name="Ali",Surname="Çetinkaya",BirthDate=new DateTime(2001,02,11),BirthPlace="Turkey"},
                new Actors(){Id=5,Name="Mehmet",Surname="Deniz",BirthDate=new DateTime(1978,09,18),BirthPlace="Turkey"},
            };
        }
    }
}
