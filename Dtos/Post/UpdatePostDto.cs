using System;
using Microsoft.AspNetCore.Http;

namespace back.Dtos.Post
{
  public class UpdatePostDto
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
  }
}