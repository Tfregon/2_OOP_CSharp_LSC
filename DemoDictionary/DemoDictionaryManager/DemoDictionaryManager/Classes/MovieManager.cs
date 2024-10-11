using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDictionaryManager.Classes
{
    public class MovieManager
    {
        // define a field which is collection (List, Dicrionary)

        private Dictionary<int,Movie> movies = new Dictionary<int,Movie>();
        // movie Id is key
        // Movie object is Value

        public MovieManager() { }

        public Dictionary<int, Movie> Movies { get => movies; set => movies = value; }

        // Methods
        public void addMovie(int id, Movie movie)
        {
            // for add movie to dictionary I need key and value 
            movies.Add(id, movie);
        }

        public void removeMovie(int id)
        {
            // if you have a key and the key exists I can remove the value
            if(movies.ContainsKey(id))
                movies.Remove(id);
        }

        public void editMovie(int id, Movie newMovie)
        {
            if(movies.ContainsKey(id))
                movies[id] = newMovie;
        }
    }
}
