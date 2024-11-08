using practica_pc2.Work.Domain.Model.ValueObjects;

namespace practica_pc2.Work.Domain.Model.Aggregates;

public partial class Product
{
    public int Id { get; }
    public string ProductCode { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public EProductStatus Status { get; private set; }
    
    public Product(string name, string description, string status)
    {
        ProductCode = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        if (Enum.TryParse(status, true, out EProductStatus parsedStatus))
        {
            Status = parsedStatus;
        }
        else
        {
            throw new ArgumentException($"Invalid status value: {status}");
        }
    }
}