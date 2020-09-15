using System.Threading.Tasks;
using back.Dtos.Nav;
using dotnet.Models;

namespace back.Services.NavDataService
{
  public interface INavDataService
  {
    Task<ServiceResponse<GetNavDataDto>> GetNavData();
  }
}