using System.Threading.Tasks;
using back.Services.BodyDataService;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BodyDataController : ControllerBase
  {
    private readonly IBodyDataService _bodyDataService;
    public BodyDataController(IBodyDataService bodyDataService)
    {
      _bodyDataService = bodyDataService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBodyData()
    {
      return Ok(await _bodyDataService.GetBodyData()); 
    }
  }
}