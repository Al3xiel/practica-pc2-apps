using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Queries;

namespace practica_pc2.Work.Domain.Services;

public interface  IProductReviewQueryService
{
    Task<IEnumerable<ProductReview>> Handle(GetAllProductReviewsByProductIdQuery query);
}