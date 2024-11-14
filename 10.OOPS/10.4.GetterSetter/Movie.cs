using System;

namespace MovieSpace
{
    public class Movie
    {
        // Private fields
        private string title;
        private string director;
        private string rating;

        // Constructor to initialize the Movie object
        public Movie(string title, string director, string rating)
        {
            this.Title = title; // Set through property
            this.Director = director; // Set through property
            this.Rating = rating; // Set through property with validation
        }

        // Public property for Title (Encapsulating the private field)
        public string Title
        {
            get { return title; } // Getter to access the value
            set { title = value; } // Setter to set the value
        }

        // Public property for Director (Encapsulating the private field)
        public string Director
        {
            get { return director; } // Getter to access the value
            set { director = value; } // Setter to set the value
        }

        // Public property for Rating with validation (Encapsulating the private field)
        public string Rating
        {
            get { return rating; } // Getter to access the value
            set
            {
                // Set the value only if it's valid, otherwise set to "NR"
                if (value == "G" || value == "PG-13" || value == "Nr" || value == "R")
                {
                    rating = value;
                }
                else
                {
                    rating = "NR"; // Default value if invalid
                }
            }
        }
    }
}
