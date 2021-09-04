using System.Threading.Tasks;
using Application.Common.Models;
using Application.Dto;
using Application.WebmotorsSwagger.Queries.GetWebMotorsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class WebMotoraController : BaseApiController
    {

        [HttpGet("Make")]
        public async Task<ActionResult<ServiceResult<WebMotorsDto>>> GetMake()
        {
            return await Mediator.Send(new GetWebMotorsQuery());
        }

        [HttpGet("Model")]
        public async Task<ActionResult<ServiceResult<WebMotorsDto>>> GetModel(int makeId)
        {
            return await Mediator.Send(new GetWebMotorsQuery(){MakeID = makeId});
        }

        [HttpGet("Version")]
        public async Task<ActionResult<ServiceResult<WebMotorsDto>>> GetVersion(int modelId)
        {
            return await Mediator.Send(new GetWebMotorsQuery(){ModelID = modelId});
        }

        [HttpGet("Vehicles")]
        public async Task<ActionResult<ServiceResult<WebMotorsDto>>> GetVehicles(int page)
        {
            return await Mediator.Send(new GetWebMotorsQuery(){Page = page});
        }
    }
}
