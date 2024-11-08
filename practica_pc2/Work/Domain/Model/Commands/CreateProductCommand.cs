using practica_pc2.Work.Domain.Model.ValueObjects;

namespace practica_pc2.Work.Domain.Model.Commands;

public record CreateProductCommand(string Name, string Description, string Status);