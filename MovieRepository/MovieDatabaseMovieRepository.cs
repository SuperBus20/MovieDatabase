using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseDTO;
using System.Linq;

namespace MovieRepository
{
    public class MovieDatabaseMovieRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        public MovieDatabaseMovieRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieManager"));
        }

        public bool AddMovie(Movie movieToAdd)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                //determine if movie exists
                Movie existingMovie = db.Movies.FirstOrDefault(x => x.Title.ToLower() == movieToAdd.Title.ToLower());

                if (existingMovie == null)
                {
                    // doesn't exist, add it
                    db.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Movie> SearchByGenre(string genre)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Genre == genre).ToList();
            }
        }
        public List<Movie> SearchByTitle(string title)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Title == title).ToList();
            }
        }

    }

}
