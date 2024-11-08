using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Commands;

namespace practica_pc2.Work.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
}