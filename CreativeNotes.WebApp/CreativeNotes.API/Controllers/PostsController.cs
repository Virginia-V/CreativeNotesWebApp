using CreativeNotes.Bll.Interfaces;
using CreativeNotes.Common.Dtos.Posts;
using Microsoft.AspNetCore.Mvc;

namespace CreativeNotes.API.Controllers
{
    [Route("api/posts")]
    public class PostsController : AppBaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsAsync()
        {
            var posts =  await _postService.GetPostsAsync();
            return Ok(posts);
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostAsync(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostDto postDto)
        {
            await _postService.CreatePostAsync(postDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostAsync(int id, [FromBody] UpdatePostDto postDto)
        {
            await _postService.UpdatePostAsync(id, postDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            await _postService.DeletePostAsync(id);
            return Ok();
        }
    }
}
