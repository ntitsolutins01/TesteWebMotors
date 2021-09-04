using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.ExternalServices.WebMotors.Request;
using Application.ExternalServices.WebMotors.Response;

namespace Application.Common.Interfaces
{
    public interface IWebmotorsService
    {
        Task<ServiceResult<WebMotorsResponse>> GetWebmotors(WebMotorsRequest request,
            CancellationToken cancellationToken);
    }
}