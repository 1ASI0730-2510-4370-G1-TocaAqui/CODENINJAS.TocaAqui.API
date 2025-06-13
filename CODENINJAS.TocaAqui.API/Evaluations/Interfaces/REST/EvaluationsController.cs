using CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
public class EvaluationsController : ControllerBase
{
    private readonly EvaluationCommandService _commandService;
    private readonly EvaluationQueryService _queryService;

    public EvaluationsController(
        EvaluationCommandService commandService,
        EvaluationQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateEvaluation([FromBody] CreateEvaluationCommand command)
    {
        var result = await _commandService.Handle(command);
        return CreatedAtAction(nameof(GetEvaluationById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvaluationById(Guid id)
    {
        var evaluation = await _queryService.Handle(new GetEvaluationByIdQuery(id));
        if (evaluation == null) return NotFound();
        return Ok(evaluation);
    }

    [HttpGet("entity/{entityType}/{entityId}")]
    public async Task<IActionResult> GetEvaluationsForEntity(string entityType, Guid entityId)
    {
        var evaluations = await _queryService.Handle(new GetEvaluationsByEntityQuery(entityType, entityId));
        return Ok(evaluations);
    }
}