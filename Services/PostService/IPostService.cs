using System.Collections.Generic;
using System.Threading.Tasks;
using back.Dtos.Post;
using dotnet.Models;


namespace back.Services.PostService
{
    public interface IPostService
    {
      Task<ServiceResponse<List<GetPostDto>>> GetAllPost();
      Task<ServiceResponse<GetPostDto>> GetPost(int id);
      Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto post);
      Task<ServiceResponse<GetPostDto>> UpdatePost(int id);
      Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id);
    
    }
}