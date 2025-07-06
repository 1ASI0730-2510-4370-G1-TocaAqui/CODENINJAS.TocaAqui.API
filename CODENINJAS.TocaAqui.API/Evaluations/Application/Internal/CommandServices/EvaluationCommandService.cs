using System.Threading.Tasks;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

namespace CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.CommandServices
{
    public interface IEvaluationCommandService
    {
        Task<Evaluation> CreateEvaluationAsync(Evaluation evaluation);
    }

    public class EvaluationCommandService : IEvaluationCommandService
    {
        // Inyectar repositorio aquí
        public EvaluationCommandService() { }

        public async Task<Evaluation> CreateEvaluationAsync(Evaluation evaluation)
        {
            await Task.CompletedTask;
            // Lógica para crear y guardar la evaluación
            // ...
            return evaluation;
        }
    }
}
