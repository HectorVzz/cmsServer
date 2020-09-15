using AutoMapper;
using back.Dtos;
using back.Dtos.Nav;
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
      CreateMap<GetBodyDataDto, BodyData>();
      CreateMap<BodyData, GetBodyDataDto>();
      CreateMap<NavData, GetNavDataDto>();
      CreateMap<GetNavDataDto, NavData>();
    }
  }
}