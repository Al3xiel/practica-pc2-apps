using practica_pc2.Shared.Domain.Repositories;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace practica_pc2.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}