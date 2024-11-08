using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Queries;
using practica_pc2.Work.Domain.Repositories;
using practica_pc2.Work.Domain.Services;

namespace practica_pc2.Work.Application.Internal.QueryServices;

public class ProductReviewQueryService(IProductReviewRepository productReviewRepository) : IProductReviewQueryService
{
    public async Task<IEnumerable<ProductReview>> Handle(GetAllProductReviewsByProductIdQuery query)
    {
        if (query.ProductId<= 0)
        {
            throw new ArgumentException("CompanyId must be greater than zero.");
        }
        return await productReviewRepository.FindProductReviewsByProductIdAsync(query.ProductId);
    }
}