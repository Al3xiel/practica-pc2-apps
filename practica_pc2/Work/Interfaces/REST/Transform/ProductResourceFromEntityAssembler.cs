using practica_pc2.Work.Domain.Model.Aggregates;
using practica_pc2.Work.Interfaces.REST.Resources;

namespace practica_pc2.Work.Interfaces.REST.Transform;

public class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(entity.Id, entity.ProductCode, entity.Name, entity.Description, entity.Status.ToString());
    }
}