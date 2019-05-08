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
        string theatreName;
        string city;
        string address;
        int numberOfScreen;
        List<int> screens = new List<int>();

        public Theatre(string theatreName, string city, string address, int numberOfScreen)
        {
            Random rnd = new Random();
            this.theatreID = rnd.Next(1000, 2000);
            this.theatreName = theatreName;
            this.city = city;
            this.address = address;
            this.numberOfScreen = numberOfScreen;

            for (int i = 1; i <= numberOfScreen; i++)
            {
                this.screens.Add(i);
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
        public int screenID = 1000;
        public SortedList<int, string> seats = new SortedList<int, string>();

        public Screen()
        {
            screenID++;
            for (int i = 1; i <= 50; i++)
            {
                seats.Add(i, "Vacant");
            }
        }
    }

    class Show
    {
        public int ShowID;
        int MovieID;
        int TheatreID;
        int ScreenID;
        DateTime StartDate;
        DateTime EndDate;
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
        string username, password, usertype;

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

    class Booking
    {
        public int BookingID =1000;
        DateTime BookingDate = DateTime.Now;
        public int ShowID;
        public string CustomerName;
        public int NumberOfSeats;
        public string SeatType;
        public decimal Amount;
        public string Email;
        public string BookingStatus;
        public List<int> SeatNumbers = new List<int>();

        public Booking(int ShowID, string CustomerName, int NumberOfSeats, string SeatType, string Email, Screen screen1, Show show1)
        {
            this.ShowID = ShowID;
            this.CustomerName = CustomerName;
            this.NumberOfSeats = NumberOfSeats;
            this.SeatType = SeatType;
            int VacantSeat = 0;
            foreach (string s in screen1.seats.Values)
            {
                if (s == "Vacant")
                    VacantSeat++;
            }

            if (NumberOfSeats < VacantSeat && NumberOfSeats > 1 && NumberOfSeats < 4)
            {
                for (int i = 0; i < NumberOfSeats; i++)
                {
                    int key = screen1.seats.IndexOfValue("Vacant");
                    screen1.seats[key] = "Reserved";
                    SeatNumbers.Add(key);
                }
                BookingStatus = "Success";
            }
            else
            {
                Console.WriteLine("Enter Seat Type as- Platinum, Gold or Silver.");
                Console.WriteLine("Enter Number of Seats between 1 to 4.");
                BookingStatus = "Fail";
            }

            if (SeatType.ToLower() == "platinum")
                Amount = NumberOfSeats * show1.PlatinumSeatRate;
            else if (SeatType.ToLower() == "gold")
                Amount = NumberOfSeats * show1.GoldSeatRate;
            else if (SeatType.ToLower() == "silver")
                Amount = NumberOfSeats * show1.SilverSeatRate;
            else
                Console.WriteLine("Enter Seat Type as- Platinum, Gold or Silver.");

            this.Email = Email;
        }
    }
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
                                if (a.movieID == h.movieID)                               
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
        public bool AddTheatre(Theatre t)
        {
            return true;
        }
        public bool UpdateTheatre(Theatre t)
        {
            return true;
        }
        public bool AddMovie(Movie m)
        {
            return true;
        }
        public bool UpdateMovie(Movie m)
        {
            return true;
        }
        public bool AddShow(Show s)
        {
            return true;
        }
        public bool UpdateShow(Show s)
        {
            return true;
        }
        public bool DeleteShow(int showID)
        {
            return true;
        }
        public bool AddAgent(User u)
        {
            return true;
        }

        public List<Theatre> GetAllTheatres()
        {
            return List<Theatre>;
        }
        public List<Movie> GetAllMovies()
        {
            return List<Movie>;
        }
        public List<Show> GetAllShows()
        {
            return List<Show>;
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
            Show show1 = new Show(movie1.movieID, t1.theatreID, screen1.screenID, startdate, enddate, 350, 200, 180);
            show1.DisplayShowDetails();

            User user1 = new User("Madhuresh", "abc@123", "AGENT");

            Booking booking1 = new Booking(show1.ShowID, "Madhuresh", 3, "Gold", "madhuresh@outlook.com", screen1, show1);
            Console.WriteLine("-------Booking Details--------");
            Console.WriteLine("Amount: {0}", booking1.Amount);
            Console.WriteLine("Booking Status: {0}", booking1.BookingStatus);

        }
    }
}
