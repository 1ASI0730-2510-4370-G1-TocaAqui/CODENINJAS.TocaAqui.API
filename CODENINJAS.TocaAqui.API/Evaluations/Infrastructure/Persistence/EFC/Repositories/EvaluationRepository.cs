using System.Collections.Generic;
using System.Threading.Tasks;
using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;

namespace CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Persistence.EFC.Repositories
{
    public interface IEvaluationRepository
    {
        Task<Evaluation> AddAsync(Evaluation evaluation);
        Task<IEnumerable<Evaluation>> ListAsync();
        Task<Evaluation> FindByIdAsync(int id);
        Task<IEnumerable<Evaluation>> FindByEventIdAsync(int eventId);
    }

    public class EvaluationRepository : IEvaluationRepository
    {
        public async Task<Evaluation> AddAsync(Evaluation evaluation)
        {
            // Implementar persistencia
            await Task.CompletedTask;
            return evaluation;
        }

        public async Task<IEnumerable<Evaluation>> ListAsync()
        {
            // Implementar persistencia
            await Task.CompletedTask;
            return new List<Evaluation>();
        }

        public async Task<Evaluation> FindByIdAsync(int id)
        {
            // Implementar persistencia
            await Task.CompletedTask;
            return new Evaluation(); // Retorna una instancia por defecto para evitar CS8603
        }

        public async Task<IEnumerable<Evaluation>> FindByEventIdAsync(int eventId)
        {
            // Implementar persistencia
            await Task.CompletedTask;
            return new List<Evaluation>();
        }
    }
}
