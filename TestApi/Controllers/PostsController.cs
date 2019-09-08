using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.DAL;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private AppDbContext _context;
        public PostsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            return _context.Posts;
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            return post;
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult> Post(Post post)
        {
          await  _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async  Task<ActionResult> Put(int id, Post post)
        {
            Post postdb = await _context.Posts.FindAsync(id);
            if (postdb == null) return NotFound();
            if (id != post.Id) return BadRequest();

            postdb.Title = post.Title;
            postdb.Content = post.Content;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Post postdb = await _context.Posts.FindAsync(id);
            if (postdb == null) return BadRequest();
            _context.Posts.Remove(postdb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
