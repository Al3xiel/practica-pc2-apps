using practica_pc2.Work.Domain.Model.Commands;
using practica_pc2.Work.Interfaces.REST.Resources;

namespace practica_pc2.Work.Interfaces.REST.Transform;

public class CreateProductCommandResourceFromEntityAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Name, resource.Description, resource.Status);
    }
}