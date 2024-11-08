using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Queries;
using practica_pc2.Work.Domain.Repositories;
using practica_pc2.Work.Domain.Services;

namespace practica_pc2.Work.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository): IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
}