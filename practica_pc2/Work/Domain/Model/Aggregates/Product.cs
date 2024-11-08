using practica_pc2.Work.Domain.Model.ValueObjects;

namespace practica_pc2.Work.Domain.Model.Aggregates;

public partial class Product
{
    public int Id { get; }
    public string ProductCode { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public EProductStatus Status { get; private set; }
    
    public Product(string productCode, string name, string description, EProductStatus status)
    {
        ProductCode = productCode;
        Name = name;
        Description = description;
        Status = status;
    }
}