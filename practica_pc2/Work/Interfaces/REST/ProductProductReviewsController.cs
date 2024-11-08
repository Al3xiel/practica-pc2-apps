using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Queries;
using practica_pc2.Work.Domain.Services;
using practica_pc2.Work.Interfaces.REST.Resources;
using practica_pc2.Work.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace practica_pc2.Work.Interfaces.REST;

[ApiController]
[Route("/api/v1/products/{productId}/reviews")]
[Produces (MediaTypeNames.Application.Json)]
[Tags("Product Reviews")]
public class ProductProductReviewsController(IProductReviewQueryService productReviewQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all product reviews by product id",
        Description = "Get all product reviews by product id",
        OperationId = "GetProductReviewsByProductId"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The product reviews with the given product id",
        typeof(IEnumerable<ProductReviewResource>))]
    public async Task<IActionResult> GetProductReviewsByProductId([FromRoute] int productId)
    {
        var getAllProductReviewsByProductIdQuery = new GetAllProductReviewsByProductIdQuery(productId);
        var productReviews = await productReviewQueryService.Handle(getAllProductReviewsByProductIdQuery);
        var productReviewResources =
            productReviews.Select(ProductReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productReviewResources);
    }
}