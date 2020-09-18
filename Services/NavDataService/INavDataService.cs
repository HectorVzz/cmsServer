using System.Threading.Tasks;
using back.Dtos.Nav;
using back.Dtos.NavData;
using dotnet.Models;

namespace back.Services.NavDataService
{
  public interface INavDataService
  {
    Task<ServiceResponse<GetNavDataDto>> GetNavData();
    Task<ServiceResponse<GetNavDataDto>> UpdateNavData(UpdateNavDataDto updateNavDataDto);
  }
}