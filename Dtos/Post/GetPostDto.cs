using System;
using Microsoft.AspNetCore.Http;

namespace back.Dtos.Post
{
  public class GetPostDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Image { get; set; }
  }
}