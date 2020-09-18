using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back.Dtos;
using back.Dtos.BodyData;
using back.Models;
using dotnet.Data;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Services.BodyDataService
{
  public class BodyDataService : IBodyDataService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public BodyDataService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task<ServiceResponse<GetBodyDataDto>> UpdateBodyData(UpdateBodyDataDto updateBodyDataDto)
    {
      ServiceResponse<GetBodyDataDto> serviceResponse = new ServiceResponse<GetBodyDataDto>();
      BodyData bodyData = await _context.BodyData.FirstOrDefaultAsync(bd => bd.Id == 1);
      bodyData.Title = updateBodyDataDto.Title;
      bodyData.Description = updateBodyDataDto.Description;
      _context.BodyData.Update(bodyData);
      await _context.SaveChangesAsync();
      serviceResponse.Data = _mapper.Map<GetBodyDataDto>(bodyData);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetBodyDataDto>> GetBodyData()
    {
      ServiceResponse<GetBodyDataDto> serviceResponse = new ServiceResponse<GetBodyDataDto>();
      BodyData bodyData = await _context.BodyData.FirstOrDefaultAsync(bd => bd.Id == 1);
      serviceResponse.Data = _mapper.Map<GetBodyDataDto>(bodyData);
      return serviceResponse;
    }
  }
}