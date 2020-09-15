using AutoMapper;
using back.Dtos.Post;
using back.Models;


namespace back
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
          CreateMap<Post, GetPostDto>();
          CreateMap<AddPostDto, Post>();
        }
    }
}