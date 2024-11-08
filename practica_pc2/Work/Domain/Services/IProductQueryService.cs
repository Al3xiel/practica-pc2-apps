using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Domain.Model.Queries;

namespace practica_pc2.Work.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);
}