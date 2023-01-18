using CreativeNotes.Bll.Interfaces;
using CreativeNotes.Common.Dtos.Posts;
using Microsoft.AspNetCore.Mvc;

namespace CreativeNotes.API.Controllers
{
    [Route("api/posts")]
    public class PostsController : AppBaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService, ILogger<PostsController> logger) : base(logger)
        {
            _postService = postService;
        }

        [HttpGet]
        public Task<IActionResult> GetPostsAsync()
        {
            return HandleAsync(() => _postService.GetPostsAsync());
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetPostAsync(int id)
        {
            return HandleAsync(() => _postService.GetPostByIdAsync(id));
        }

        [HttpPost]
        public Task<IActionResult> CreatePostAsync([FromBody] CreatePostDto postDto)
        {
            return HandleAsync(() => _postService.CreatePostAsync(postDto));
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdatePostAsync(int id, [FromBody] UpdatePostDto postDto)
        {
            return HandleAsync(() => _postService.UpdatePostAsync(id, postDto));
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeletePostAsync(int id)
        {
            return HandleAsync(() => _postService.DeletePostAsync(id));
        }
    }
}
