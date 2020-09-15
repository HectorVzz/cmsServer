using System.Threading.Tasks;
using back.Services.NavDataService;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class NavDataController : ControllerBase
  {
    private readonly INavDataService _navDataService;
    public NavDataController(INavDataService navDataService)
    {
      _navDataService = navDataService;
    }
     public async Task<IActionResult> GetNAvData()
    {
      return Ok(await _navDataService.GetNavData()); 
    }
  }
}