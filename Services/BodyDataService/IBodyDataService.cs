using System.Threading.Tasks;
using back.Dtos;
using back.Dtos.BodyData;
using dotnet.Models;

namespace back.Services.BodyDataService
{
  public interface IBodyDataService
  {
    Task<ServiceResponse<GetBodyDataDto>> GetBodyData();
    Task<ServiceResponse<GetBodyDataDto>> UpdateBodyData(UpdateBodyDataDto updateBodyDataDto);
  }
}