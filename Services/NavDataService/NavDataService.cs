using System.Threading.Tasks;
using AutoMapper;
using back.Dtos.Nav;
using back.Dtos.NavData;
using back.Models;
using dotnet.Data;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Services.NavDataService
{
  public class NavDataService : INavDataService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public NavDataService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<ServiceResponse<GetNavDataDto>> GetNavData()
    {
      ServiceResponse<GetNavDataDto> serviceResponse = new ServiceResponse<GetNavDataDto>();
      NavData navData = await _context.NavData.FirstOrDefaultAsync(bd => bd.Id == 1);
      serviceResponse.Data = _mapper.Map<GetNavDataDto>(navData);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetNavDataDto>> UpdateNavData(UpdateNavDataDto updateNavDataDto)
    {
       ServiceResponse<GetNavDataDto> serviceResponse = new ServiceResponse<GetNavDataDto>();
      NavData navData = await _context.NavData.FirstOrDefaultAsync(bd => bd.Id == 1);
      navData.Title = updateNavDataDto.Title;
      _context.NavData.Update(navData);
      await _context.SaveChangesAsync();
      serviceResponse.Data = _mapper.Map<GetNavDataDto>(navData);
      return serviceResponse;
    }
  }
}