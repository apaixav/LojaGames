﻿using LojaGames.Data;
using LojaGames.Model;
using Microsoft.EntityFrameworkCore;

namespace LojaGames.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {

        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                .Include(c => c.Produto)
                .ToListAsync();
        }

        public async Task<Categoria> GetById(long id)
        {
            try
            {
                var CategoriaUpdate = await _context.Categorias.Include(t => t.Produto)
                    .FirstAsync(i => i.id == id);

                return CategoriaUpdate;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Categoria>> GetByTipo(string tipo)
        {
            var Categorias = await _context.Categorias
                .Include(c => c.Produto)
                .Where(p => p.tipo.Contains(tipo)).ToListAsync();
            return Categorias;
        }

        public async Task<Categoria?> Create(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> Update(Categoria categoria)
        {
            var CategoriaUpdate = await _context.Categorias.FindAsync(categoria.id);

            if (CategoriaUpdate is null)
                return null;

            _context.Entry(CategoriaUpdate).State = EntityState.Detached;
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(Categoria Categoria)
        {
            _context.Remove(Categoria);
            await _context.SaveChangesAsync();
        }

    }
}
