using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back.Dtos.Post;
using back.Models;
using dotnet.Data;
using dotnet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace back.Services.PostService
{
  public class PostService : IPostService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _environment;

    public PostService(IMapper mapper, DataContext context, IWebHostEnvironment environment)
    {
      _mapper = mapper;
      _context = context;
      _environment = environment;
    }
    public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
    {
      ServiceResponse<List<GetPostDto>> serviceResponse = new ServiceResponse<List<GetPostDto>>();
      try
      {
        Post post = _mapper.Map<Post>(newPost);
        post.Date = DateTime.Now;

        if (newPost.Image.Length > 0)
        {
          string filePath = Path.Combine("wwwroot", "images",
            DateTime.Now.Ticks + Path.GetRandomFileName() + newPost.Image.FileName);
          using (var stream = System.IO.File.Create(filePath))
          {
            await newPost.Image.CopyToAsync(stream);
            post.Image = filePath.Substring(8, filePath.Length - 8);
          }
        }


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
        File.Delete("wwwroot\\" + postToRemove.Image);
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

    public async Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto editedPost, int id)
    {
      ServiceResponse<GetPostDto> serviceResponse = new ServiceResponse<GetPostDto>();
      try
      {
        Post postToEdit = await _context.Posts.FirstOrDefaultAsync((p) => p.Id == id);
        postToEdit.Title = editedPost.Title;
        postToEdit.Description = editedPost.Description;
        postToEdit.Date = DateTime.Now;
        if (editedPost.Image != null)
        {
          File.Delete("wwwroot\\" + postToEdit.Image);
          string filePath = Path.Combine("wwwroot", "images",
            DateTime.Now.Ticks + Path.GetRandomFileName() + editedPost.Image.FileName);
          using (var stream = System.IO.File.Create(filePath))
          {
            await editedPost.Image.CopyToAsync(stream);
            postToEdit.Image = filePath.Substring(8, filePath.Length - 8);
          }
        }
        _context.Posts.Update(postToEdit);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetPostDto>(postToEdit);
      }
      catch (System.Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = "No se pudo encontrar el post a editar";
      }
      return serviceResponse;
    }
  }
}