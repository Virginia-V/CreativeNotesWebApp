using AutoMapper;
using CreativeNotes.Bll.Interfaces;
using CreativeNotes.Common;
using CreativeNotes.Common.Dtos.Posts;
using CreativeNotes.Dal.Interfaces;
using CreativeNotes.Domain;

namespace CreativeNotes.Bll.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task CreatePostAsync(CreatePostDto dto)
        {
            var post = _mapper.Map<Post>(dto);
            await _postRepository.AddAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new InvalidOperationException(ErrorMessages.NoPostForDelete);
            }
            await _postRepository.DeleteAsync(post);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            var result = _mapper.Map<PostDto>(post);
            return result;
        }

        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var records = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDto>>(records);
        }

        public async Task UpdatePostAsync(int id, UpdatePostDto dto)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new InvalidOperationException(ErrorMessages.NoPostForUpdate);
            }
            _mapper.Map(dto, post);
            await _postRepository.UpdateAsync(post);
        }
    }
}
