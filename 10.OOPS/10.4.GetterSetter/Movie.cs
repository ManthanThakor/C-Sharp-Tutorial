using System;

namespace MovieSpace
{
    public class Movie
    {
        public string title;
        public string director;
        private string rating;


        // constructor of movie class
        public Movie(string title, string director, string rating)
        {
            this.title = title;
            this.director = director;
            this.Rating = rating;
        }

        public string Rating
        {
            get { return rating; }
            set { 
            if (value == "G" || value == "PG-13" || value == "Nr" || value == "R" )
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }
    }
}   