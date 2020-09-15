using System;

namespace back.Dtos.Post
{
  public class GetPostDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
  }
}