using System;
using Microsoft.AspNetCore.Http;

namespace back.Dtos.Post
{
  public class AddPostDto
  {
    public string Title { get; set; } = "test";
    public string Description { get; set; } = "si";
    public IFormFile Image { get; set; }
  }
}