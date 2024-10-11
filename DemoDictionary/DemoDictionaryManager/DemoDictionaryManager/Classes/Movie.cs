using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDictionaryManager.Classes
{
    public class Movie
    {
        private int id;
        private string title;
        private string director;
        private Genre genre;
        private int yearOfProduction;

        public Movie() { }

        public Movie(int id, string title, string director, Genre genre, int yearOfProduction)
        {
            this.id = id;
            this.title = title;
            this.director = director;
            this.genre = genre;
            this.yearOfProduction = yearOfProduction;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Director { get => director; set => director = value; }
        public Genre Genre { get => genre; set => genre = value; }
        public int YearOfProduction { get => yearOfProduction; set => yearOfProduction = value; }
    }
}
