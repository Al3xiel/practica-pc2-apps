using practica_pc2.Shared.Domain.Repositories;
using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Commands;
using practica_pc2.Work.Domain.Repositories;
using practica_pc2.Work.Domain.Services;

namespace practica_pc2.Work.Application.Internal.CommandServices;

public class ProductReviewCommandService(
    IProductReviewRepository productReviewRepository,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IProductReviewCommandService
{
    public async Task<ProductReview?> Handle(CreateProductReviewCommand command)
    {
        var productReview = new ProductReview(command.UserEmail, command.Rating,command.ReviewCriterion , command.Comment);
        await productReviewRepository.AddAsync(productReview);
        await unitOfWork.CompleteAsync();
        var product = await productRepository.FindByIdAsync(command.ProductId);
        productReview.Product = product;
        return productReview;
    }
}