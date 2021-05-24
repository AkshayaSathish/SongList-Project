using System;
using Newtonsoft.Json;

namespace SongAPITests.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Instruments { get; set; }

        public string Directors { get; set; }

       

        public override string ToString()
        {
            return  JsonConvert.SerializeObject(this);
        }

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
            if (songId <= (int) SongValue.MinValue)
            {
                errMsg = $"Song Id should be greater than {(int) SongValue.MinValue}";
                return false;
            }

            if (songId > (int) SongValue.MaxValue)
            {
                errMsg = $"Song Id should be less than {(int) SongValue.MaxValue}";
                return false;
            }
            errMsg = "";
            return true;
        }
    }

}