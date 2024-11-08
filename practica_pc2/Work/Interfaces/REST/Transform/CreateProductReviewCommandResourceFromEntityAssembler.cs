using practica_pc2.Work.Domain.Model.Commands;

namespace practica_pc2.Work.Interfaces.REST.Transform;

public class CreateProductReviewCommandResourceFromEntityAssembler
{
    public static CreateProductReviewCommand toCommandFromResource(CreateProductReviewCommand resource, int productId)
    {
        return new CreateProductReviewCommand(
            resource.UserEmail, 
            resource.Rating, 
            resource.ReviewCriterion, 
            resource.Comment, 
            productId);
    }
}