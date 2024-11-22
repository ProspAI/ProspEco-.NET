using System;
using Microsoft.EntityFrameworkCore;
using Proj_ProspEco.Data;
using Proj_ProspEco.Models;

namespace Proj_ProspEco.Persistencia.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly ProspEcoDbContext _context;

        public UsuarioRepository(ProspEcoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddAsync(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
