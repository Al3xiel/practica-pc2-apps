using practica_pc2.Shared.Infrastructure.Persistence.EFC.Configuration;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Repositories;
using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Repositories;

namespace practica_pc2.Work.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context): BaseRepository<Product>(context), IProductRepository
{
    
}