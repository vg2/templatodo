using api_templatodo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api_templatodo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator mediator;

    public TodoController(IMediator mediator) => this.mediator = mediator;

    [HttpGet("today")]
    public async Task<IEnumerable<TemplateToday>> Get(CancellationToken cancellationToken = default) => await this.mediator.Send(new TemplatesTodayQuery(), cancellationToken);
}
