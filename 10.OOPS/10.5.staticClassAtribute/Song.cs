using System;

namespace SongSpace
{
    public class Song
    {
        // Instance properties
        public int Title { get; set; }
        public string Artist { get; set; }
        public string Duration { get; set; }

        // Static field to count the number of songs
        private static int _songCount;

        // Static property to get the song count
        public static int SongCount
        {
            get
            {
                return _songCount;
            }
        }

        // Constructor
        public Song(int title, string artist, string duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;

            // Increment the static song count for each new song
            _songCount++;
        }
    }
}