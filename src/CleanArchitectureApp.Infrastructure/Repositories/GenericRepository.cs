using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : CommonEntity
    {
        // Assuming you have a DbContext or similar data context to interact with the database
        protected readonly ErpDatabaseContext _context;
        public GenericRepository(ErpDatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
             _context.Remove(entity);
            await _context.SaveChangesAsync();
                            
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
           return await _context.Set<T>().AsNoTracking().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(a=> a.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            //_context.Update(entity);
            //await _context.SaveChangesAsync(_cancellationToken);

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
