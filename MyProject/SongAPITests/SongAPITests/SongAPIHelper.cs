using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using SongAPITests.Models;


namespace SongAPITests
{
    public class SongAPIHelper
    {
        HttpClient client = new HttpClient();
        private string url = "http://localhost:5000/songs/";

        public void ShowSong(Song song)
        {
            Console.WriteLine($"Name: {song.Name}\tSong Id: " +
                $"{song.SongId}\tGenre: {song.Genre}");
        }

        public async Task<Song> CreateSongAsync(Song newSong)
        {
            var content = new StringContent(newSong.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{url}",  content);
            var songData = await response.Content.ReadAsStringAsync();
            var song = JsonConvert.DeserializeObject<Song>(songData);
            return song;
        }

        public async Task<Song> GetSongAsync(int id)
        {
            Song song = null;
            HttpResponseMessage response = await client.GetAsync($"{url}{id}");
            if (response.IsSuccessStatusCode)
            {
            
                var songStrData = await response.Content.ReadAsStringAsync();
                song = JsonConvert.DeserializeObject<Song>(songStrData);
            }
            return song;
        }

        public async Task<List<Song>> GetSongsAsync()
        {
            List<Song> songs = null;
            HttpResponseMessage response = await client.GetAsync($"{url}");
            if (response.IsSuccessStatusCode)
            {
                
                var songStrData = await response.Content.ReadAsStringAsync();
                songs = JsonConvert.DeserializeObject<List<Song>>(songStrData);
            }
            return songs;
        }

        public async Task<Song> UpdateSongAsync(Song updSong)
        {
            var content = new StringContent(updSong.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"{url}", content);
            var songStrData = await response.Content.ReadAsStringAsync();
            var songData = JsonConvert.DeserializeObject<Song>(songStrData);
            return songData;
        }

        public async Task<int> DeleteSongAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{url}{id}");
            var delData = await response.Content.ReadAsStringAsync();
            var numOfRows = int.Parse(delData);
            return numOfRows;
        }
    }

}