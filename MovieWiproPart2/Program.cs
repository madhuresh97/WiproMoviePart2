using System;
using System.Collections.Generic;

namespace MovieWiproPart2
{
    class Movie
    {
        int movieID;
        string movieName, director, producer, cast, story, type;
        double duration;

        public Movie(int movieID, string movieName, string director, string producer, string cast, double duration, string story, string type)
        {
            Random rnd = new Random();
            this.movieID = rnd.Next(1000, 2000);
            this.movieName = movieName;
            this.director = director;
            this.producer = producer;
            this.cast = cast;
            this.duration = duration;
            this.story = story;
            this.type = type;
            if (type != "Running" || type != "Upcoming")
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
        int theatreID;
        string theatreName;
        string city;
        string address;
        int numberOfScreen;
        List<int> screens = new List<int>();

        public Theatre(int theatreID, string theatreName, string city, string address, int numberOfScreen, List<int> screens)
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
        int screenID;
        public SortedList<int, string> seats = new SortedList<int, string>();

        public Screen(int screenID)
        {
            if (screenID > 1000)
                this.screenID = screenID;
            else
                this.screenID = 1000;

            for (int i = 1; i <= 50; i++)
            {
                this.seats.Add(i, "Vacant");
            }
        }
    }

    class Show
    {
        int ShowID;
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
            this.ShowID = rnd.Next(1000, 2000);
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
            Console.WriteLine("MovieID" + MovieID);
            Console.WriteLine("TheatreID" + TheatreID);
            Console.WriteLine("ScreenID" + ScreenID);
            Console.WriteLine("StartDate" + StartDate);
            Console.WriteLine("EndDate" + EndDate);
            Console.WriteLine("PlatinumSeatRate" + PlatinumSeatRate);
            Console.WriteLine("GoldSeatRate" + GoldSeatRate);
            Console.WriteLine("SilverSeatRate" + SilverSeatRate);
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
            if (usertype != "ADMIN" || usertype != "AGENT")
            {
                Console.WriteLine("Invalid usertype. Should be ADMIN or AGENT.");
            }
        }
    }

    class Booking
    {
        int BookingID=1000;
        DateTime BookingDate = DateTime.Now;
        int ShowID;
        string CustomerName;
        int NumberOfSeats;
        string SeatType;
        decimal Amount;
        string Email;
        string BookingStatus;
        List<int> SeatNumbers = new List<int>();

        public Booking(int ShowID, string CustomerName, int NumberOfSeats, string SeatType, string Email, Screen screen1, Show show1)
        {
            this.ShowID = ShowID;
            this.CustomerName = CustomerName;
            this.NumberOfSeats = NumberOfSeats;
            if (NumberOfSeats < 1 || NumberOfSeats > 4)
            {
                Console.WriteLine("Enter Number of Seats between 1 to 4.");
            }

            this.SeatType = SeatType;
            int VacantSeat = 0;
            foreach (string s in screen1.seats.Values)
            {
                if (s == "Vacant")
                    VacantSeat++;
            }

            if (NumberOfSeats < VacantSeat)
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
                BookingStatus = "Fail";
            }

            if (SeatType.ToLower() == "platinum")
                this.Amount = NumberOfSeats * show1.PlatinumSeatRate;
            else if (SeatType.ToLower() == "gold")
                this.Amount = NumberOfSeats * show1.GoldSeatRate;
            else if (SeatType.ToLower() == "silver")
                this.Amount = NumberOfSeats * show1.SilverSeatRate;
            else
                Console.WriteLine("Enter Seat Type as- Platinum, Gold or Silver.");

            this.Email = Email;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }
    }
}
