using MovieDatabaseDTO;
using MovieRepository;
namespace MovieDatabaseDomain

{
    public class MovieDatabaseMovieInteractor
    {
        private MovieDatabaseMovieRepository _repo;
        public MovieDatabaseMovieInteractor()
        {
            _repo = new MovieDatabaseMovieRepository();
        }
        public bool AddNewItem(Movie movieToAdd)
        {
            if (string.IsNullOrEmpty(movieToAdd.Title) || string.IsNullOrEmpty(movieToAdd.Genre))
            {
                throw new ArgumentException("Name and Genre must contain valid text.");
            }
            return _repo.AddMovie(movieToAdd);
        }
        public bool GetMoviesByTitle(string title, out List<Movie> moviesToReturn)
        {
            List<Movie> movies = _repo.SearchByTitle(title);
            moviesToReturn= movies;
            return moviesToReturn != null;
        }
        public bool GetMoviesByGenre(string genre, out List<Movie> moviesToReturn)
        {
            List<Movie> movies = _repo.SearchByGenre(genre);
            moviesToReturn = movies;
            return moviesToReturn != null;
        }

    }
}