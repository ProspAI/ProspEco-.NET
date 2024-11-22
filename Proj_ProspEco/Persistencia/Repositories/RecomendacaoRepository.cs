using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de Recomendacao.
    /// </summary>
    public interface IRecomendacaoRepository : IRepository<Recomendacao> { }

    /// <summary>
    /// Implementação do repositório para a entidade Recomendacao.
    /// </summary>
    public class RecomendacaoRepository : RepositoryBase<Recomendacao>, IRecomendacaoRepository
    {
        private readonly ProspEcoDbContext _context;

        /// <summary>
        /// Construtor do RecomendacaoRepository.
        /// </summary>
        /// <param name="context">Instância do DbContext.</param>
        public RecomendacaoRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona uma nova recomendação ao banco de dados.
        /// </summary>
        /// <param name="entity">Entidade Recomendacao.</param>
        public override async Task AddAsync(Recomendacao entity)
        {
            await _context.Recomendacoes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma recomendação do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">ID da recomendação.</param>
        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.Recomendacoes.FindAsync(id);
            if (entity != null)
            {
                _context.Recomendacoes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retorna todas as recomendações.
        /// </summary>
        public override async Task<IEnumerable<Recomendacao>> GetAllAsync()
        {
            return await Task.FromResult(_context.Recomendacoes);
        }

        /// <summary>
        /// Retorna uma recomendação pelo ID.
        /// </summary>
        /// <param name="id">ID da recomendação.</param>
        public override async Task<Recomendacao> GetByIdAsync(int id)
        {
            return await _context.Recomendacoes.FindAsync(id);
        }

        /// <summary>
        /// Atualiza uma recomendação existente.
        /// </summary>
        /// <param name="entity">Entidade Recomendacao com dados atualizados.</param>
        public override async Task UpdateAsync(Recomendacao entity)
        {
            _context.Recomendacoes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
