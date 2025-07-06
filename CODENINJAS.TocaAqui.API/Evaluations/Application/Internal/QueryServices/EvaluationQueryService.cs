using System.Collections.Generic;
using System.Threading.Tasks;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

namespace CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.QueryServices
{
    public interface IEvaluationQueryService
    {
        Task<IEnumerable<Evaluation>> GetAllEvaluationsAsync();
        Task<Evaluation> GetEvaluationByIdAsync(int id);
        Task<IEnumerable<Evaluation>> GetEvaluationsByEventIdAsync(int eventId);
        Task<double> GetAverageRatingForMusicianAsync(int musicianId);
        Task<double> GetAverageRatingForPromoterAsync(int promoterId);
    }

    public class EvaluationQueryService : IEvaluationQueryService
    {
        // Inyectar repositorio aquí
        public EvaluationQueryService() { }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluationsAsync()
        {
            // Lógica para obtener todas las evaluaciones
            await Task.CompletedTask;
            return new List<Evaluation>();
        }

        public async Task<Evaluation> GetEvaluationByIdAsync(int id)
        {
            // Lógica para obtener una evaluación por ID
            await Task.CompletedTask;
            return new Evaluation(); // Retorna una instancia por defecto para evitar CS8603
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsByEventIdAsync(int eventId)
        {
            // Lógica para obtener evaluaciones por evento
            await Task.CompletedTask;
            return new List<Evaluation>();
        }

        public async Task<double> GetAverageRatingForMusicianAsync(int musicianId)
        {
            // Lógica para promedio de músico
            await Task.CompletedTask;
            return 0.0;
        }

        public async Task<double> GetAverageRatingForPromoterAsync(int promoterId)
        {
            // Lógica para promedio de promotor
            await Task.CompletedTask;
            return 0.0;
        }
    }
}
