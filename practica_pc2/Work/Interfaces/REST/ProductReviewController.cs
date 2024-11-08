using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practica_pc2.Work.Domain.Model.Queries;
using practica_pc2.Work.Domain.Services;
using practica_pc2.Work.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace practica_pc2.Work.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Product Reviews")]
public class ProductReviewController(IProductReviewCommandService productReviewCommandService, IProductReviewQueryService productReviewQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new product review",
        Description = "Create a new product review in the system",
        OperationId = "CreateProductReview")]
    [SwaggerResponse(StatusCodes.Status201Created, "The product review was created", typeof(ProductReviewResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateProductReview([FromBody] CreateProductReviewResource resource, [FromRoute] int productId)
    {
       var createProductReviewCommand = CreateProductReviewCommandResourceFromEntityAssembler.ToCommandFromResource(resource, productId);
       var productReview = await productReviewCommandService.Handle(createProductReviewCommand);
       if(productReview is null) return BadRequest();
       var productReviewResource = ProductReviewResourceFromEntityAssembler.ToResourceFromEntity(productReview);
       return CreatedAtAction(nameof(GetProductReviewById), new { productReviewId = productReview.Id }, productReviewResource);
    }
    
    [HttpGet("{productReviewId:int}")]
    [SwaggerOperation (
        Summary = "Get product review by id",
        Description = "Get a product review by its id",
        OperationId = "GetProductReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product review was found", typeof(ProductReviewResource))]
    public async Task<IActionResult> GetProductReviewById([FromRoute] int productReviewId)
    {
        var getProductReviewByIdQuery = new GetProductReviewByIdQuery(productReviewId);
        var productReview = await productReviewQueryService.Handle(getProductReviewByIdQuery);
        if (productReview is null) return NotFound();
        var productReviewResource = ProductReviewResourceFromEntityAssembler.ToResourceFromEntity(productReview);
        return Ok(productReviewResource);
    }
}