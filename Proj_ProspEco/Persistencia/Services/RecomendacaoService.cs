using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Services
{
    public interface IRecomendacaoService
    {
        Task<IEnumerable<Recomendacao>> GetAllAsync();
        Task<Recomendacao> GetByIdAsync(int id);
        Task AddAsync(Recomendacao recomendacao);
        Task UpdateAsync(Recomendacao recomendacao);
        Task DeleteAsync(int id);
    }

    public class RecomendacaoService : IRecomendacaoService
    {
        private readonly IRecomendacaoRepository _repository;

        public RecomendacaoService(IRecomendacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Recomendacao>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Recomendacao> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Recomendacao recomendacao)
        {
            await _repository.AddAsync(recomendacao);
        }

        public async Task UpdateAsync(Recomendacao recomendacao)
        {
            await _repository.UpdateAsync(recomendacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
