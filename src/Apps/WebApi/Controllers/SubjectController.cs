using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Dto;
using Application.Subjects.Commands.Create;
using Application.Subjects.Commands.Delete;
using Application.Subjects.Commands.Update;
using Application.Subjects.Queries.GetSubjectById;
using Application.Subjects.Queries.GetSubjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class SubjectController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<SubjectDto>>>> GetAllSubject(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllSubjectsQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<SubjectDto>>> GetSubjectById(int id)
        {
            return Ok(await Mediator.Send(new GetSubjectByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<SubjectDto>>> Create(CreateSubjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<SubjectDto>>> Update(UpdateSubjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<SubjectDto>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSubjectCommand { Id = id }));
        }
    }
}
