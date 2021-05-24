using System;
using NUnit.Framework;
using Newtonsoft.Json;
using SongAPITests.Models;
using System.Globalization;
using SongAPI.Services;

namespace SongAPITests
{
    [TestFixture]
    public class SongTests
    {
         private SongAPIHelper apiHelper;
        [SetUp]

        public void Setup()
        {
            apiHelper = new SongAPIHelper();
        }
        [Test]
        [TestCase("admin","admin123")]
        [TestCase("user","user123")]

        public void LoginTest(string userName,string password)
        {
            var svc = new UserService();
            var res = svc.Login(userName, password, out string token, out string errMsg);
            Assert.IsTrue(res);
            Assert.IsNotNull(token);
            Assert.AreEqual(errMsg,"");
        }

        [Test]
        [TestCase("admin","a123")]
        [TestCase("user","u123")]

        public void LoginFailTest(string userName,string password)
        {
            var svc = new UserService();
            var res = svc.Login(userName, password, out string token, out string errMsg);
            Assert.IsFalse(res);
            Assert.AreEqual(token,"");
            Assert.IsNotNull(errMsg);
        }


        [Test]
        
        public void GetSongsTest()
        {
            var songs = apiHelper.GetSongsAsync().Result;
            Console.WriteLine(JsonConvert.SerializeObject(songs));
            Assert.IsNotNull(songs);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetSongTest(int songId)
        {
            var song = apiHelper.GetSongAsync(songId).Result;
            Assert.IsNotNull(song);
            Assert.IsNotNull(song.Name);
        }

        [Test]
        public void InsertSongTest()
        {
            var newSong = new Song();
           // newSong.SingerId = 6;
            newSong.Name = "Yaakai Thiri Kadhal Sudar";
            newSong.Genre = "Disco";
            newSong.Instruments = "Drum Kit";
            newSong.Directors = "Harish Jayaraj";
            

            var insSong = apiHelper.CreateSongAsync(newSong).Result;
            Assert.IsNotNull(insSong);
            Assert.Greater(insSong.SongId, 0);

    //Get Song and Validate
    //GetSongTest(insSong.SongId);
            var song = apiHelper.GetSongAsync(insSong.SongId).Result;
            Assert.IsNotNull(song);
            Assert.IsNotNull(song.Name);

            Assert.AreEqual(newSong.Name, song.Name);

    //Updated Song
            var updSong = new Song();
           // updSong.SingerId = 5; 
            updSong.Name = "Orasadha Usuratha";
            updSong.Genre = "Lute";
            updSong.Instruments = "Flute";
            updSong.Directors = "Harish Jayaraj";
            
            updSong.SongId = insSong.SongId;

            var updatedSong = apiHelper.UpdateSongAsync(updSong).Result;
            Assert.IsNotNull(updatedSong);
            Assert.AreEqual(updatedSong.Name, updSong.Name);

            song = apiHelper.GetSongAsync(insSong.SongId).Result;
            Assert.IsNotNull(song);

    //Delete Song
            var delSongId = apiHelper.DeleteSongAsync(insSong.SongId).Result;
            Assert.AreEqual(insSong.SongId,delSongId);

            song = apiHelper.GetSongAsync(insSong.SongId).Result;
            Assert.IsNull(song);
        }
    }
}