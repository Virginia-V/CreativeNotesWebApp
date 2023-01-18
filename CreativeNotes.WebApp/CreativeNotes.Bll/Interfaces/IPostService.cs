using CreativeNotes.Common.Dtos.Posts;

namespace CreativeNotes.Bll.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task CreatePostAsync(CreatePostDto dto);
        Task UpdatePostAsync(int id, UpdatePostDto dto);
        Task DeletePostAsync(int id);
    }
}
