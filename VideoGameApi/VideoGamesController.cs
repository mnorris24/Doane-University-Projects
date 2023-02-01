using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/videogames")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGameContext _context;

        public VideoGamesController(VideoGameContext context)
        {
            _context = context;
        }

        // GET: api/VideoGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/VideoGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(long id)
        {
            var videoGame = await _context.TodoItems.FindAsync(id);

            if (videoGame == null)
            {
                return NotFound();
            }

            return videoGame;
        }

        // PUT: api/VideoGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGame(long id, VideoGame videoGame)
        {
            if (id != videoGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(videoGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VideoGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoGame>> PostTodoItem(VideoGame videoGame)
        {
            _context.TodoItems.Add(videoGame);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetVideoGame), new { id = videoGame.Id }, videoGame);
        }

        // DELETE: api/VideoGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(long id)
        {
            var videoGame = await _context.TodoItems.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(videoGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoGameExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
