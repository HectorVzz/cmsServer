using System.Threading.Tasks;
using back.Dtos;
using dotnet.Models;

namespace back.Services.BodyDataService
{
  public interface IBodyDataService
  {
    Task<ServiceResponse<GetBodyDataDto>> GetBodyData();
  }
}