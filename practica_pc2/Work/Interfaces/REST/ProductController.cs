using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practica_pc2.Work.Domain.Model.Queries;
using practica_pc2.Work.Domain.Services;
using practica_pc2.Work.Interfaces.REST.Resources;
using practica_pc2.Work.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace practica_pc2.Work.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Products")]
public class ProductController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService
    ) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new product",
        Description = "Create a new product",
        OperationId = "CreateProduct"
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "The product was created", typeof(ProductResource))]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, productResource);
    }
    
    [HttpGet("{productId:int}")]
    [SwaggerOperation(
        Summary = "Get a product by id",
        Description = "Get a product by id",
        OperationId = "GetProductById"
        )]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was found", typeof(ProductResource))]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var getProductByIdQuery = new GetProductByIdQuery(productId);
        var product = await productQueryService.Handle(getProductByIdQuery);
        if (product is null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
}