using AutoMapper;
using CreativeNotes.Common.Dtos.Posts;
using CreativeNotes.Domain;

namespace CreativeNotes.Bll.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<UpdatePostDto, Post>();
            CreateMap<CreatePostDto, Post>();

        }
    }
}
