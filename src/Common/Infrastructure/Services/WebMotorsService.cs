using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Common.Models;
using Application.ExternalServices.WebMotors.Request;
using Application.ExternalServices.WebMotors.Response;
using Domain.Enums;

namespace Infrastructure.Services
{
    public class WebMotorsService : IWebmotorsService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "webmotors-api";

        public WebMotorsService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        //{
        //    return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
        //        .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        //}

        public async Task<ServiceResult<WebMotorsResponse>> GetWebmotors(WebMotorsRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<WebMotorsRequest, WebMotorsResponse>(ClientApi, string.Concat("Model", StringExtensions.ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}