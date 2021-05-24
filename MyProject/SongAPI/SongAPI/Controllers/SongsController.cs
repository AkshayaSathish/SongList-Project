using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Models;
using SongAPI.Services;


namespace SongAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // ******************************************************
                // 2. Run SQL statement
                // ******************************************************
                SongService abcd = new SongService();
                List<Song> songs = abcd.GetAllSongs();
                if(songs.Count <= 0)
                {
                    return NotFound("No songs exist");
                }

                // ******************************************************
                // 3. Return Data
                // ******************************************************
                return Ok(songs);
            }
            catch (Exception ex)
            {
                // ******************************************************
                // 4. If Exception return 500
                // ******************************************************
                LogError(ex);
                return StatusCode(500, "Unknown Error");
            }
        }

        [HttpGet("{id}")]
        //[HttpGet]
        public IActionResult Get([FromRoute] string id)
        {
            try
            {
                // ******************************************************
                // 1. Validation
                // ******************************************************
                bool res = Song.IsSongIdValid(id, out int songId, out string errMsg);
                if (!res)  //res == false  //res == true
                {
                    BadRequest(errMsg);
                }

                // ******************************************************
                // 2. Run SQL statement
                // ******************************************************
                SongService SongService = new SongService();
                Song song = SongService.GetSong(songId);
                if(song == null)
                {
                    return NotFound("Song with Song Id - " + songId + " does not exist.");
                }

                // ******************************************************
                // 3. Return Data
                // ******************************************************
                return Ok(song);
            }
            catch (Exception ex)
            {
                // ******************************************************
                // 4. If Exception return 500
                // ******************************************************
                LogError(ex);
                return StatusCode(500, "Unknown Error");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Song updSong)
        {
            try
            {
                //1. Validation
                bool res = Song.IsSongValid(updSong, out string errMsg);
                if (res == false)  //!res
                {
                    return BadRequest(errMsg);
                }

                //2. Execute DB
                SongService sda = new SongService();
                int numRows = sda.UpdateSong(updSong);
                if (numRows == 0)
                {
                    return BadRequest("Invalid Song. Cannot Insert.");
                }
                //3. Return Data
                return Ok(updSong);
            }
            catch(Exception ex)
            {
                // 4. If Exception return 500
                LogError(ex);
                return StatusCode(500, "Unknown Error - " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Song newSong)
        {
            try
            {
                //1. Validation
                bool res = Song.IsSongValid(newSong, out string errMsg);
                if (res == false)  //!res
                {
                    return BadRequest(errMsg);
                }

                //2. Execute DB
                SongService sda = new SongService();
                
                int newSongId = sda.InsertSong(newSong);
                if (newSongId <= 0)
                {
                    return BadRequest("Invalid Song. Cannot Insert.");
                }
                //3. Return Data
                newSong.SongId = newSongId;
                return Ok(newSong);
            }
            catch(Exception ex)
            {
                // 4. If Exception return 500
                LogError(ex);
                return StatusCode(500, "Unknown Error - " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            try
            {
                // ******************************************************
                // 1. Validation
                // ******************************************************
                bool res = Song.IsSongIdValid(id, out int songId, out string errMsg);
                if (!res)  //res == false  //res == true
                {
                    BadRequest(errMsg);
                }

                // ******************************************************
                // 2. Run SQL statement
                // ******************************************************
                SongService SongService = new SongService();
                int numOfRows = SongService.DeleteSong(songId);
                if(numOfRows <= 0)
                {
                    return NotFound("Song with Song Id - " + songId + " does not exist.");
                }

                // ******************************************************
                // 3. Return Data
                // ******************************************************
                return Ok(songId);
            }
            catch (Exception ex)
            {
                // ******************************************************
                // 4. If Exception return 500
                // ******************************************************
                LogError(ex);
                return StatusCode(500, "Unknown Error");
            }
        }

        private void LogError(Exception ex)
        {
            //Do Something to Log an Error
        }
    }
}
