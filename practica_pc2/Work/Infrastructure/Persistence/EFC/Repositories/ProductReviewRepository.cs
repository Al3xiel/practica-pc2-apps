using Microsoft.EntityFrameworkCore;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Configuration;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Repositories;
using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Repositories;

namespace practica_pc2.Work.Infrastructure.Persistence.EFC.Repositories;

public class ProductReviewRepository(AppDbContext context): BaseRepository<ProductReview>(context), IProductReviewRepository
{
    public async Task<IEnumerable<ProductReview>> FindProductReviewsByProductIdAsync(int productId) =>
        
        await Context.Set<ProductReview>()
            .Include(p => p.Product)
            .Where(p => p.ProductId == productId)
            .ToListAsync();
    
}