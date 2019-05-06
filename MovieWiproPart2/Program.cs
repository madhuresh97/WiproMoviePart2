﻿using System;
using System.Collections.Generic;

namespace MovieWiproPart2
{
    class Movie
    {
        public int movieID;
        string movieName, director, producer, cast, story, type;
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
        int BookingID=1000;
        DateTime BookingDate = DateTime.Now;
        int ShowID;
        string CustomerName;
        int NumberOfSeats;
        string SeatType;
        public decimal Amount;
        string Email;
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
