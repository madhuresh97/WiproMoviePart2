using System;
using System.Collections.Generic;

namespace MovieWiproPart2
{
    namespace Exceptions
    {
        class InvalidScreenCountException : Exception
        {
            public InvalidScreenCountException(string msg) : base(msg)
            { }
        }
        class InvalidMovieTypeException : Exception
        {
            public InvalidMovieTypeException(string msg) : base (msg)
            { }
        }
    }
    public class RandomGenerator
    {
        public static Random R = new Random();
    }
    interface IAdmin
    {
        bool AddTheatre(Theatre obj);
        bool UpdateTheatre(Theatre obj);
        bool AddMovie(Movie obj);
        bool UpdateMovie(Movie obj);
        bool AddShow(Show obj);
        bool UpdateShow(Show obj);
        bool DeleteShow(int ShowID);
        bool AddAgent(User obj);
        List<Theatre> GetAllTheatres();
        List<Movie> GetAllMovies();
        List<Show> GetAllShows();
    }
    class MovieTicketing
    {
        public static List<User> UserInformation = new List<User>();
        public static List<Theatre> Theatres = new List<Theatre>();
        public static List<Movie> Movies = new List<Movie>();
        public static List<Show> shows = new List<Show>();
        public static List<Booking> Bookings = new List<Booking>();
    }
    class Movie
    {
        public int movieID;
        public string movieName, director, producer, cast, story, type;
        public double duration;

        public Movie(string movieName, string director, string producer, string cast, double duration, string story, string type)
        {
            Random rnd = new Random();
            movieID = rnd.Next(1000, 2000);
            this.movieName = movieName;
            this.director = director;
            this.producer = producer;
            this.cast = cast;
            this.duration = duration;
            this.story = story;
            this.type = type;
            if (type.Equals("Running") == false && type.Equals("Upcoming") == false)
            {
                Console.WriteLine("Enter type as Running or Upcoming.");
            }                
        }

        public void DisplayMovieDetails()
        {
            Console.WriteLine("Movie ID: " + movieID);
            Console.WriteLine("Movie Name: " + movieName);
            Console.WriteLine("Director: " + director);
            Console.WriteLine("Producer: " + producer);
            Console.WriteLine("Cast: " + cast);
            Console.WriteLine("Duration: " + duration);
            Console.WriteLine("Story: " + story);
            Console.WriteLine("Type: " + type);
        }
    }

    class Theatre
    {
        public int theatreID;
        public string theatreName;
        public string city;
        public string address;
        public int numberOfScreen;
        List<int> screens = new List<int>();

        public Theatre(string theatreName, string city, string address, int numberOfScreen)
        {
            Random rnd = new Random();
            theatreID = rnd.Next(1000, 2000);
            this.theatreName = theatreName;
            this.city = city;
            this.address = address;
            this.numberOfScreen = numberOfScreen;

            for (int i = 1; i <= numberOfScreen; i++)
            {
                screens.Add(i);
            }
        }

        public void DisplayTheatreDetails()
        {
            Console.WriteLine("Theatre ID: " + theatreID);
            Console.WriteLine("Theatre Name: " + theatreName);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Number of Screens: " + numberOfScreen);
        }
    }

    class Screen
    {
        public static int ScreenID;
        public SortedList<int, string> Seats = new SortedList<int, string>();
        public Screen()
        {
            ScreenID = RandomGenerator.R.Next(1000, 10000);
            for (int i = 0; i < 50; i++)
            {
                Seats.Add(i, "Vacant");
            }
        }
    }

    class Show
    {
        public int ShowID;
        public int MovieID;
        public int TheatreID;
        public int ScreenID;
        public DateTime StartDate;
        public DateTime EndDate;
        public decimal PlatinumSeatRate;
        public decimal GoldSeatRate;
        public decimal SilverSeatRate;

        public Show(int MovieID, int TheatreID, int ScreenID, DateTime StartDate, DateTime EndDate, decimal PlatinumSeatRate, decimal GoldSeatRate, decimal SilverSeatRate)
        {
            Random rnd = new Random();
            ShowID = rnd.Next(1000, 2000);
            this.MovieID = MovieID;
            this.TheatreID = TheatreID;
            this.ScreenID = ScreenID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.PlatinumSeatRate = PlatinumSeatRate;
            this.GoldSeatRate = GoldSeatRate;
            this.SilverSeatRate = SilverSeatRate;
        }

        public void DisplayShowDetails()
        {

            Console.WriteLine("ShowID: " + ShowID);
            Console.WriteLine("MovieID: " + MovieID);
            Console.WriteLine("TheatreID: " + TheatreID);
            Console.WriteLine("ScreenID: " + ScreenID);
            Console.WriteLine("StartDate: " + StartDate);
            Console.WriteLine("EndDate: " + EndDate);
            Console.WriteLine("PlatinumSeatRate: " + PlatinumSeatRate);
            Console.WriteLine("GoldSeatRate: " + GoldSeatRate);
            Console.WriteLine("SilverSeatRate: " + SilverSeatRate);
        }
    }

    class User
    {
        public string username, password, usertype;

        public User(string username, string password, string usertype)
        {
            this.username = username;
            this.password = password;
            this.usertype = usertype;
            if (usertype.Equals("ADMIN") == false && usertype.Equals("AGENT") == false)
            {
                Console.WriteLine("Invalid usertype. Should be ADMIN or AGENT.");
            }
        }
    }

    #region BookingClass
    public class Booking
    {
        public int BookingID;
        public DateTime BookingDate = DateTime.Today;
        public int ShowID;

        #region CustomerName
        private string _CustomerName;
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                if (value == "" || value == null)
                {
                    Console.WriteLine("Customer name is empty. Try again\n");
                    _CustomerName = "No_name";
                }
                else
                {
                    _CustomerName = value;
                }
            }
        }
        #endregion

        #region NumberOfSeats
        private int _NumberOfSeats;
        public int NumberOfSeats
        {
            get
            {
                return _NumberOfSeats;
            }
            set
            {
                if (value >= 1 || value <= 4)
                {
                    _NumberOfSeats = value;
                }
                else
                {
                    Console.WriteLine("Invalid number of seats. Cannot be more than 4\nAssigning default value of 1");
                }
            }
        }
        #endregion

        #region SeatType
        private string _SeatType;
        public string SeatType
        {
            get
            {
                return _SeatType;
            }
            set
            {
                if (value.Equals("platinum", StringComparison.InvariantCultureIgnoreCase) || value.Equals("gold", StringComparison.InvariantCultureIgnoreCase) || value.Equals("silver", StringComparison.InvariantCultureIgnoreCase))
                {
                    _SeatType = value;
                }
                else
                {
                    Console.WriteLine("Invalid Seat type");
                }
            }
        }
        #endregion

        #region Amount
        public decimal Amount;

        #endregion

        #region Email
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (value == "" || value == null)
                {
                    Console.WriteLine("Email address is empty. Try again\n");
                }
                else
                {
                    _Email = value;
                }
            }
        }
        #endregion

        public string BookingStatus;

        public static List<int> SeatNumbers = new List<int>();
        public Booking(int SI, string CN, int NOS, string ST, string MAIL)
        {
            BookingID = RandomGenerator.R.Next(1000, 10000);
            ShowID = SI;
            CustomerName = CN;
            NumberOfSeats = NOS;
            SeatType = ST;
            Email = MAIL;
            for (int i = 0; i < MovieTicketing.shows.Count; i++)
            {
                var v = MovieTicketing.shows[i];
                if (v.ShowID == ShowID)
                {
                    if (SeatType.Equals("platinum", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Amount = NumberOfSeats * v.PlatinumSeatRate;
                    }
                    if (SeatType.Equals("gold", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Amount = NumberOfSeats * v.GoldSeatRate;
                    }
                    if (SeatType.Equals("silver", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Amount = NumberOfSeats * v.SilverSeatRate;
                    }
                }
            }
        }
    }
    #endregion
    abstract class TicketBooking
    {
        public int BookTicket(Booking obj)
        {
            if (obj.ShowID == 0 || obj.CustomerName == "" || obj.NumberOfSeats <= 0 || obj.SeatType == "" || obj.Email == "")
            {
                Console.WriteLine("Booking Details can't be empty");
                return -1;
            }
            else
            {
                MovieTicketing.Bookings.Add(obj);
                return obj.BookingID;
            }
        }
        public void PrintTicket(int BookingId)
        {
            int TheatID = 0;
            int ScrID = 0;
            string MovName = "";
            if (BookingId > 0)
            {
                for (int x = 0; x < MovieTicketing.Bookings.Count; x++)
                {
                    var v = MovieTicketing.Bookings[x];
                    for (int y = 0; y < MovieTicketing.shows.Count; y++)
                    {
                        var h = MovieTicketing.shows[y];
                        if (h.ShowID == v.ShowID)
                        {
                            TheatID = h.TheatreID;
                            ScrID = h.ScreenID;
                            for (int z = 0; z < MovieTicketing.Movies.Count; z++)
                            {
                                var a = MovieTicketing.Movies[z];
                                if (a.movieID == h.MovieID)                               
                                    MovName = a.movieName;
                            }
                        }
                    }
                    string s = " ";
                    for (int n = 0; n < Booking.SeatNumbers.Count; n++)
                        s = s + " " + Booking.SeatNumbers[n];

                    if (v.BookingID == BookingId)
                    {
                        Console.WriteLine("\nBooking ID:        Booking Date:           Customer Name:");
                        Console.WriteLine("{0}              {1}    {2}", BookingId, v.BookingDate, v.CustomerName);
                        Console.WriteLine("\nSeats:               Seat type:          Seat Numbers:");
                        Console.WriteLine("{0}                     {1}           {2}", v.NumberOfSeats, v.SeatType, s);
                        Console.WriteLine("\nMovie Name:          Show ID:            Theatre ID/Screen ID:");
                        Console.WriteLine("{0}                  {1}                 {2}/{3}", MovName, v.ShowID, TheatID, ScrID);
                        Console.WriteLine("\nAmount Paid:                             Booking Status");
                        Console.WriteLine("{0}                                      {1}\n", v.Amount, v.BookingStatus);
                    }
                }
            }
            else
                Console.WriteLine("Booking ID should be a non negative value");
        }
    }

    class Administrator : TicketBooking, IAdmin
    {
        MovieTicketing MT = new MovieTicketing();
        public bool AddTheatre(Theatre obj)
        {
            if (obj.theatreName == "" || obj.city == "" || obj.address == "")
            {
                Console.WriteLine("The theatre details should not be empty");
            }
            if (obj == null)
            {
                throw new NullReferenceException("The theatre details should not be null");
            }
            if (obj.numberOfScreen <= 0)
            {
                throw new Exceptions.InvalidScreenCountException("Invalid Screen Count. The number of seats should not be less than or equal to zero");
            }
            else
            {
                MovieTicketing.Theatres.Add(obj);
                return true;
            }
        }
        public bool UpdateTheatre(Theatre obj)
        {
            for (int i = 0; i < MovieTicketing.Theatres.Count; i++)
            {
                var v = MovieTicketing.Theatres[i];

                if ((v.theatreName.Equals(obj.theatreName, StringComparison.InvariantCultureIgnoreCase)) && (v.city.Equals(obj.city, StringComparison.InvariantCultureIgnoreCase)) && (v.address.Equals(obj.address, StringComparison.InvariantCultureIgnoreCase)))
                {
                    Console.WriteLine("Theatre details are available in the database:");
                    Console.WriteLine("Theatre name is {0}", v.theatreName);
                    Console.WriteLine("City name is {0}", v.city);
                    Console.WriteLine("Address is {0}", v.address);
                    Console.WriteLine("Number of screens are {0}", v.numberOfScreen);
                    Console.WriteLine("Enter the updated theatre details");

                    Console.WriteLine("Enter new/old Theatre name");
                    string TheatreName = Console.ReadLine();
                    Console.WriteLine("Enter new/old Address");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter new/old City name");
                    string Cityname = Console.ReadLine();
                    if (Cityname == "" || address == "" || TheatreName == "")
                    {
                        Console.WriteLine("Theatre details should not be empty");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Enter Number of seats");
                        int NOS = Convert.ToInt32(Console.ReadLine());
                        if (NOS <= 0)
                        {
                            throw new Exceptions.InvalidScreenCountException("Invalid Screen Count. The number of seats should not be less than or equal to zero");
                        }

                        else
                        {
                            int Index = 0;
                            Theatre theatre = new Theatre(TheatreName, Cityname, address, NOS);
                            for (int I = 0; i < MovieTicketing.Theatres.Count; i++)
                            {
                                var V = MovieTicketing.Theatres[I];
                                if (V.theatreName == obj.theatreName && V.address == obj.address)
                                {
                                    Index = i;
                                }
                            }
                            MovieTicketing.Theatres.RemoveAt(Index);
                            MovieTicketing.Theatres.Insert(Index, theatre);
                        }
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("No matching theatres in the database");
                }
            }

            return false;
        }
        public bool AddMovie(Movie obj)
        {
            if (obj.movieName == "" || obj.producer == "" || obj.story == "" || obj.director == "" || obj.cast == "")
            {
                Console.WriteLine("The Movie details should not be empty");
                return false;
            }
            if (obj == null)
            {
                throw new NullReferenceException("The Movie details should not be null");
            }

            if (obj.duration <= 0)
            {
                Console.WriteLine("The Movie details should not be empty");
                return false;
            }
            if ((obj.type.Equals("running", StringComparison.InvariantCultureIgnoreCase)) || (obj.type.Equals("upcoming", StringComparison.InvariantCultureIgnoreCase)))
            {
                MovieTicketing.Movies.Add(obj);
                return true;
            }
            else
            {
                throw new Exceptions.InvalidMovieTypeException("Invalid Movie type. The movie type should be either 'Running' or 'Upcoming'");

            }
        }
        public bool UpdateMovie(Movie obj)
        {
            for (int i = 0; i < MovieTicketing.Movies.Count; i++)
            {
                var v = MovieTicketing.Movies[i];

                if ((v.movieName == obj.movieName) && (v.producer == obj.producer) && (v.story == obj.story) && (v.director == obj.director) && (v.cast == obj.cast))
                {
                    Console.WriteLine("\nMovie details are available in the database:");
                    Console.WriteLine("Movie name is {0}", v.movieName);
                    Console.WriteLine("Producer is {0}", v.producer);
                    Console.WriteLine("Directed by {0}", v.director);
                    Console.WriteLine("Cast of the movie includes {0}", v.cast);
                    Console.WriteLine("Story of the movie is {0}", v.story);
                    Console.WriteLine("Movie is {0}", v.type);
                    Console.WriteLine("Duration of the Movie is {0}", v.duration);
                    Console.WriteLine("\nEnter the updated Movie details");

                    Console.WriteLine("Enter the old/updated Movie Name");
                    string movieName = Console.ReadLine();
                    Console.WriteLine("Enter the old/updated Producer Name");
                    string producer = Console.ReadLine();
                    Console.WriteLine("Enter the old/updated Director Name");
                    string director = Console.ReadLine();
                    Console.WriteLine("Enter the old/updated Story details");
                    string story = Console.ReadLine();
                    Console.WriteLine("Enter the old/updated Cast members");
                    string cast = Console.ReadLine();
                    Console.WriteLine("Enter the old/update Duration");
                    int duration = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the old/update Movie Type i.e 'Running' or 'Upcoming'");
                    string type = Console.ReadLine();
                    if (movieName == "" || producer == "" || director == "" || story == "" || cast == "" || type == "")
                    {
                        Console.WriteLine("Movie details should not be empty");
                        return false;
                    }
                    else
                    {
                        if (duration <= 0)
                        {
                            throw new Exceptions.InvalidScreenCountException("Invalid Screen Count. The number of seats should not be less than or equal to zero");
                        }

                        else
                        {
                            int Index = 0;
                            Movie movie = new Movie(movieName, director, producer, cast, duration, story, type);
                            for (int I = 0; I < MovieTicketing.Movies.Count; I++)
                            {
                                var V = MovieTicketing.Movies[I];
                                if (V.movieName == obj.movieName && V.producer == obj.producer && v.director == obj.director)
                                {
                                    Index = I;
                                }
                            }
                            MovieTicketing.Movies.RemoveAt(Index);
                            MovieTicketing.Movies.Insert(Index, movie);
                        }
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("No matching movies in the database. Update not possible");
                }
            }
            return false;
        }
        public bool AddShow(Show obj)
        {
            Console.WriteLine();
            if (obj.EndDate == null || obj.MovieID == 0 || obj.ScreenID == 0 || obj.StartDate == null || obj.TheatreID == 0 || obj.GoldSeatRate == 0 || obj.PlatinumSeatRate == 0 || obj.SilverSeatRate == 0)
            {
                Console.WriteLine("The Show details should not be empty");
                return false;
            }
            if (obj == null)
            {
                throw new NullReferenceException("The Show details should not be null");
            }

            if (Screen.ScreenID == obj.ScreenID)
            {
                MovieTicketing.shows.Add(obj);
                return true;
            }
            else
            {
                Console.WriteLine("Inappropriate data found");
                return false;
            }
        }
        public bool UpdateShow(Show obj)
        {
            for (int i = 0; i < MovieTicketing.shows.Count; i++)
            {
                var v = MovieTicketing.shows[i];

                if ((v.StartDate == obj.StartDate) && (v.EndDate == obj.EndDate) && (v.GoldSeatRate == obj.GoldSeatRate) && (v.PlatinumSeatRate == obj.PlatinumSeatRate) && (v.SilverSeatRate == obj.SilverSeatRate))
                {
                    Console.WriteLine("Movie details are available in the database:");
                    Console.WriteLine("Show start date is {0}", v.StartDate);
                    Console.WriteLine("Shows' end date is {0}", v.EndDate);
                    Console.WriteLine("Price of Gold tier seats is {0}", v.GoldSeatRate);
                    Console.WriteLine("price of Platinum tier seats is by {0}", v.PlatinumSeatRate);
                    Console.WriteLine("Price of Silver tier seats is {0}", v.SilverSeatRate);

                    Console.WriteLine("\nEnter the updated Show details");
                    //specify what is being entered

                    Console.WriteLine("Enter old/updated First show date");
                    DateTime Start = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter old/updated Last show date");
                    DateTime End = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter old/updated Platinum seat rate");
                    decimal Platinum = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter old/updated Gold Seat rate");
                    decimal Gold = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter old/updated Silver Seat rate");
                    decimal Silver = Convert.ToDecimal(Console.ReadLine());

                    if (Start == null || End == null || Platinum <= 0 || Gold <= 0 || Silver <= 0)
                    {
                        Console.WriteLine("Show details should not be empty");
                        return false;
                    }
                    else
                    {
                        int Index = 0;
                        Show SHOW = new Show(obj.MovieID, obj.TheatreID, obj.ScreenID, Start, End, Platinum, Gold, Silver);
                        for (int I = 0; I < MovieTicketing.shows.Count; I++)
                        {
                            var V = MovieTicketing.shows[I];
                            if (V.EndDate == obj.EndDate && V.StartDate == obj.StartDate && V.PlatinumSeatRate == obj.PlatinumSeatRate && V.GoldSeatRate == obj.GoldSeatRate)
                            {
                                Index = I;
                            }
                        }
                        MovieTicketing.shows.RemoveAt(Index);
                        MovieTicketing.shows.Insert(Index, SHOW);
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("No matching Shows in the database. Update not possible");
                }
            }
            return false;
        }
        public bool DeleteShow(int showID)
        {
            int index = 0;
            foreach (var v in MovieTicketing.shows)
            {
                if (v.ShowID == showID)
                {
                    MovieTicketing.shows.RemoveAt(index);
                    return true;
                }
                index++;
            }
            return false;
        }
        public bool AddAgent(User obj)
        {
            if (obj.username == "" || obj.password == "" || obj.usertype == "")
            {
                Console.WriteLine("The User information should not be empty");
                return false;
            }
            if (obj == null)
            {
                throw new NullReferenceException("The User details should not be null");
            }
            else
            {
                MovieTicketing.UserInformation.Add(obj);
                return true;
            }
        }

        public List<Theatre> GetAllTheatres()
        {
            return MovieTicketing.Theatres;
        }
        public List<Movie> GetAllMovies()
        {
            return MovieTicketing.Movies;
        }
        public List<Show> GetAllShows()
        {
            return MovieTicketing.shows;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Movie Details--------");
            Movie movie1 = new Movie("Kesari", "Anurag Singh", "Dharma Productions", "Akshay, Parineeti", 180, "Drama, History", "Running");
            movie1.DisplayMovieDetails();

            Console.WriteLine("-------Theatre Details--------");
            Theatre t1 = new Theatre("PVR", "Mumbai", "Cuffe Parade", 7);
            t1.DisplayTheatreDetails();

            Screen screen1 = new Screen();

            DateTime startdate = new DateTime(2019, 4, 3, 12, 0, 0);
            DateTime enddate = startdate.AddMinutes(movie1.duration);
            Console.WriteLine("-------Show Details--------");
            Show show1 = new Show(movie1.movieID, t1.theatreID, 1000, startdate, enddate, 350, 200, 180);
            show1.DisplayShowDetails();

            User user1 = new User("Madhuresh", "abc@123", "AGENT");

            Booking booking1 = new Booking(show1.ShowID, "Madhuresh", 3, "Gold", "madhuresh@outlook.com");
            Console.WriteLine("-------Booking Details--------");
            Console.WriteLine("Amount: {0}", booking1.Amount);
            Console.WriteLine("Booking Status: {0}", booking1.BookingStatus);

        }
    }
}
