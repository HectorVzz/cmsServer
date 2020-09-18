using System;
using System.Threading.Tasks;
using back.Dtos.Post;
using back.Services.PostService;
using dotnet.Data;
using dotnet.Dtos.user;
using dotnet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PostController : ControllerBase
  {
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
      _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
      return Ok(await _postService.GetAllPost());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getPost(int id)
    {
      return Ok(await _postService.GetPost(id));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddPost([FromForm] AddPostDto newPost)
    {
      return Ok(await _postService.AddPost(newPost));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
      return Ok(await _postService.DeletePost(id));
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePost([FromForm]UpdatePostDto updatePostDto, int id)
    {
      return Ok(await _postService.UpdatePost(updatePostDto,id));
    }
  }
}