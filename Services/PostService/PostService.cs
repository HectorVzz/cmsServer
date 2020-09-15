using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back.Dtos.Post;
using back.Models;
using dotnet.Data;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Services.PostService
{
  public class PostService : IPostService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public PostService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
    {
      ServiceResponse<List<GetPostDto>> serviceResponse = new ServiceResponse<List<GetPostDto>>();
      try
      {
        Post post = _mapper.Map<Post>(newPost);
        post.Date = DateTime.Now;

        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        serviceResponse.Data = (_context.Posts.Select(p => _mapper.Map<GetPostDto>(p))).ToList();

      }
      catch (System.Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetPostDto>>> GetAllPost()
    {
      ServiceResponse<List<GetPostDto>> serviceResponse = new ServiceResponse<List<GetPostDto>>();
      serviceResponse.Data = (_context.Posts.Select(p => _mapper.Map<GetPostDto>(p))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetPostDto>> GetPost(int id)
    {
      ServiceResponse<GetPostDto> serviceResponse = new ServiceResponse<GetPostDto>();

      Post post = await _context.Posts.FirstOrDefaultAsync((p) => p.Id == id);
      if (post != null)
      {
        serviceResponse.Data = _mapper.Map<GetPostDto>(post);
      }
      else
      {
        serviceResponse.Success = false;
        serviceResponse.Message = "No se pudo encontrar el post a borrar";
      }
      return serviceResponse;
    }


    public async Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id)
    {
      ServiceResponse<List<GetPostDto>> serviceResponse = new ServiceResponse<List<GetPostDto>>();
      try
      {
        Post postToRemove = await _context.Posts.FirstOrDefaultAsync((p) => p.Id == id);
        _context.Remove<Post>(postToRemove);
        await _context.SaveChangesAsync();
        serviceResponse.Data = (_context.Posts.Select(p => _mapper.Map<GetPostDto>(p))).ToList();
      }
      catch (System.Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = "No se pudo encontrar el post a borrar";
      }
      return serviceResponse;
    }

    public Task<ServiceResponse<GetPostDto>> UpdatePost(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}