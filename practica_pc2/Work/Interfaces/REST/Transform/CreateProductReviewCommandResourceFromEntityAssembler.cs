using practica_pc2.Work.Domain.Model.Commands;
using practica_pc2.Work.Interfaces.REST.Resources;

namespace practica_pc2.Work.Interfaces.REST.Transform;

public class CreateProductReviewCommandResourceFromEntityAssembler
{
    public static CreateProductReviewCommand ToCommandFromResource(CreateProductReviewResource resource, int productId)
    {
        return new CreateProductReviewCommand(
            resource.UserEmail, 
            resource.Rating, 
            resource.ReviewCriterion, 
            resource.Comment, 
            productId);
    }
}