using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Application.ExternalServices.WebMotors.Request;
using MapsterMapper;

namespace Application.WebmotorsSwagger.Queries.GetWebMotorsQuery
{
    public class GetWebMotorsQuery : IRequestWrapper<WebMotorsDto>
    {
        public int Id { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int Page { get; set; }
    }

    public class GetCurrentWeatherForecastQueryHandler : IRequestHandlerWrapper<GetWebMotorsQuery, WebMotorsDto>
    {
        private readonly IWebmotorsService _openWeatherService;
        private readonly IMapper _mapper;

        public GetCurrentWeatherForecastQueryHandler(IWebmotorsService openWeatherService, IMapper mapper)
        {
            _openWeatherService = openWeatherService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<WebMotorsDto>> Handle(GetWebMotorsQuery request, CancellationToken cancellationToken)
        {
            var openWeatherRequest = _mapper.Map<WebMotorsRequest>(request);

            var result = await _openWeatherService.GetWebmotors(openWeatherRequest, cancellationToken);

            return result.Succeeded
                ? ServiceResult.Success(_mapper.Map<WebMotorsDto>(result.Data))
                : ServiceResult.Failed<WebMotorsDto>(ServiceError.ServiceProvider);
        }
    }
}