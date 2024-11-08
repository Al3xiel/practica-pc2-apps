using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Interfaces.REST.Resources;

namespace practica_pc2.Work.Interfaces.REST.Transform;

public class ProductReviewResourceFromEntityAssembler
{
    public static ProductReviewResource ToResourceFromEntity(ProductReview entity)
    {
        return new ProductReviewResource(
            entity.Id,
            entity.UserEmail,
            entity.Rating,
            entity.ReviewCriterion.ToString(),
            entity.Comment,
            ProductResourceFromEntityAssembler.ToResourceFromEntity(entity.Product)
        );
    }
}