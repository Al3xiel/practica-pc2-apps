using practica_pc2.Shared.Domain.Repositories;
using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Commands;
using practica_pc2.Work.Domain.Repositories;
using practica_pc2.Work.Domain.Services;

namespace practica_pc2.Work.Application.Internal.CommandServices;

public class ProductCommandService(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.Description, command.Status);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }
}