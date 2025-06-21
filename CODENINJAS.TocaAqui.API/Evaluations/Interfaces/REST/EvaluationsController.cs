using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Services;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Transform;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Evaluations")]
public class EvaluationsController : ControllerBase
{
    private readonly IEvaluationQueryService _evaluationQueryService;
    private readonly IEvaluationCommandService _evaluationCommandService;

    public EvaluationsController(IEvaluationQueryService evaluationQueryService, IEvaluationCommandService evaluationCommandService)
    {
        _evaluationQueryService = evaluationQueryService;
        _evaluationCommandService = evaluationCommandService;
    }

    /// <summary>
    /// Gets evaluations filtered by type ("artist" o "venue")
    /// </summary>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets evaluations by type",
        Description = "Gets all evaluations filtered by type (artist/venue)",
        OperationId = "GetEvaluationsByType")]
    [SwaggerResponse(200, "Evaluations found", typeof(IEnumerable<EvaluationResource>))]
    public async Task<ActionResult<IEnumerable<EvaluationResource>>> GetByType([FromQuery] string type)
    {
        try
        {
            var query = new GetAllEvaluationsByTypeQuery(type);
            var evaluations = await _evaluationQueryService.Handle(query);

            var resources = evaluations.Select(EvaluationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting evaluations: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates a new evaluation (artist o venue)
    /// </summary>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new evaluation",
        Description = "Creates a new artist or venue evaluation",
        OperationId = "CreateEvaluation")]
    [SwaggerResponse(201, "The evaluation was created", typeof(EvaluationResource))]
    [SwaggerResponse(400, "The evaluation was not created")]
    public async Task<ActionResult<EvaluationResource>> CreateEvaluation([FromBody] EvaluationResource resource)
    {
        var createEvaluationCommand = CreateEvaluationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var evaluationEntity = await _evaluationCommandService.Handle(createEvaluationCommand);

        if (evaluationEntity is null)
            return BadRequest();

        var evaluationResource = EvaluationResourceFromEntityAssembler.ToResourceFromEntity(evaluationEntity);
        // Asumes que Id es autoincremental y único
        return CreatedAtAction(nameof(GetByType), new { type = evaluationEntity.Type }, evaluationResource);
    }
}
