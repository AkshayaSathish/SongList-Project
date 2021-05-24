using System;

namespace SongAPI.Models
{
    public class Song
    {
        public Song()
        {

        }
      

        public int SongId { get; set; }

        public string SingerId { get; set; }

       // public int SingerId { get; set; }

        public String Name { get; set; }

        public string Genre { get; set; }

        public string Instruments { get; set; }

        public string Directors { get; set; }

        public static bool IsSongValid(Song ns, out string errMsg)
        {
            bool res = IsSongNameValid(ns.Name, out errMsg);
            if(!res)
            {
                return false;
            }

            errMsg = "";
            return true;
        }

        public static bool IsSongNameValid(string songName, out string errMsg)
        {
            if (songName.Length <= 1 || songName.Trim().Length <= 1)
            {
                errMsg = "Name cannot be empty. Please input a name";
                return false;
            }
            errMsg = "";
            return true;
        }

        public static bool IsSongIdValid(string strSongId, out int songId, out string errMsg)
        {
            // ******************************************************
            // Validation
            // Check SongId is not string, > 0 && < 999
            // ******************************************************
            bool res = Int32.TryParse(strSongId, out songId);
            if (!res)  //res == false  //res == true
            {
                errMsg = "Invalid Input. Please input a valid SongId";
                return false;
            }

            // Check if SongId > 0
            if (songId <= 0)
            {
                errMsg = "Song Id should be greater than 0";
                return false;
            }

            if (songId > 999)
            {
                errMsg = "Song Id should be less than 999";
                return false;
            }
            errMsg = "";
            return true;
        }
    }

}