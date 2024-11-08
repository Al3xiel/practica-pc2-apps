using practica_pc2.Shared.Domain.Repositories;
using practica_pc2.Work.Domain.Model.Aggregates;

namespace practica_pc2.Work.Domain.Repositories;

public interface IProductReviewRepository : IBaseRepository<ProductReview>
{
    Task<IEnumerable<ProductReview>> FindProductReviewsByProductIdAsync(int productId);
}