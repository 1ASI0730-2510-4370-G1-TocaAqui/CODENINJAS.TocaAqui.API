using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Resources;

namespace CODENINJAS.TocaAqui.API.Evaluations.Interfaces.REST.Controllers
{
    [ApiController]
    [Route("api/v1/evaluations")]
    public class EvaluationsController : ControllerBase
    {
        private readonly IEvaluationCommandService _commandService;
        private readonly IEvaluationQueryService _queryService;

        public EvaluationsController(IEvaluationCommandService commandService, IEvaluationQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<ActionResult<EvaluationResource>> CreateEvaluation([FromBody] CreateEvaluationResource resource)
        {
            // Mapear resource a entidad y guardar
            // ...
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluationResource>>> GetAll()
        {
            // Obtener todas las evaluaciones
            // ...
            await Task.CompletedTask;
            return Ok();
        }
    }
}
