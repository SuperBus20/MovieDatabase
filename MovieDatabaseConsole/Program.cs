using MovieDatabaseDomain;
using MovieDatabaseDTO;

MovieDatabaseMovieInteractor _movieDatabaseMovieInteractor = new MovieDatabaseMovieInteractor();

//LoadStartUpData();

Console.WriteLine("Hi, welcome to June's movie database!");
Console.WriteLine("Please sellect how you would like to search. \n 1: Search by Title. \n 2: Search by Genre.");
int userInput = Convert.ToInt32(Console.ReadLine());
if (userInput == 1)
{
    Console.WriteLine("please enter the title you would like to search for");
    string userTitle = Console.ReadLine();

    bool doesMovieExist = _movieDatabaseMovieInteractor.GetMoviesByTitle(userTitle.ToLower(), out List<Movie> returnedMovies);
    if (doesMovieExist && returnedMovies.Count != 0)
    {
        foreach (Movie movie in returnedMovies)
        {
            Console.WriteLine($"Movie title: {movie.Title} | Movie Genre: {movie.Genre} | Movie Length: {movie.RunTime} Minutes");
        }
    }
    else if (!doesMovieExist || returnedMovies.Count == 0)
    { Console.WriteLine("There are no movies by that title in the database."); }
}
else if(userInput == 2)
{
    Console.WriteLine("please enter the genre you would like to search for.");
    string userGenre = Console.ReadLine();

    bool doesMovieExist = _movieDatabaseMovieInteractor.GetMoviesByGenre(userGenre.ToLower(), out List<Movie> returnedMovies);
    if (doesMovieExist && returnedMovies.Count != 0)
    {
        foreach (Movie movie in returnedMovies)
        {
            Console.WriteLine($"Movie title: {movie.Title} | Movie Genre: {movie.Genre} | Movie Length: {movie.RunTime} Minutes");
        }
    }
    else if (!doesMovieExist || returnedMovies.Count == 0)
    { Console.WriteLine("There are no movies with that genre in the database"); }
}
else
{
    Console.WriteLine("that is not a valid option.");
}












Console.WriteLine("Press any key to exit");
Console.ReadKey();







void LoadStartUpData()
{
    foreach (Movie movie in BuildItemCollection())
    {
        if (_movieDatabaseMovieInteractor.AddNewItem(movie) == true)
        {
            Console.WriteLine($"{movie.Title} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{movie.Title} was NOT added to the database.");
        }
    }
}



List<Movie> BuildItemCollection()
{
    List<Movie> initialMovies = new List<Movie>();
    initialMovies.Add(new Movie() { Title = "A Christmas Carol", Genre = "Fantasy" , RunTime = 149.3});
    initialMovies.Add(new Movie() { Title = "Charlotte's Web", Genre = "Fantasy" , RunTime = 160.61 });
    initialMovies.Add(new Movie() { Title = "The Golden Voyage of Sinbad", Genre = "Fantasy", RunTime = 180.55 });
    initialMovies.Add(new Movie() { Title = "The Hobbit", Genre = "Fantasy", RunTime = 173.43 });
    initialMovies.Add(new Movie() { Title = "Petey Wheatstraw", Genre = "Fantasy", RunTime = 150.76 });
    initialMovies.Add(new Movie() { Title = "The Eminence in Shadow", Genre = "Isekai", RunTime = 182.77 });
    initialMovies.Add(new Movie() { Title = "Mushoku Tensei", Genre = "Isekai" , RunTime = 169.71 });
    initialMovies.Add(new Movie() { Title = "That Time I Got Reincarnated as a Slime", Genre = "Isekai" , RunTime = 136.98 });
    initialMovies.Add(new Movie() { Title = "The Rising of the Shield Hero", Genre = "Isekai" , RunTime = 149.86 });
    initialMovies.Add(new Movie() { Title = "The Saga of Tanya the Evil", Genre = "Isekai" , RunTime = 138.32 });
    initialMovies.Add(new Movie() { Title = "Doctor X", Genre = "Horror" , RunTime = 174.81 });
    initialMovies.Add(new Movie() { Title = "Frankenstein", Genre = "Horror" , RunTime = 124.62 });
    initialMovies.Add(new Movie() { Title = "The Black Cat", Genre = "Horror" , RunTime = 196.60 });
    initialMovies.Add(new Movie() { Title = "Invisible Ghost", Genre = "Horror" , RunTime = 152.72 });
    initialMovies.Add(new Movie() { Title = "Fog Island", Genre = "Horror" , RunTime = 145.90 });
    return initialMovies;
}
