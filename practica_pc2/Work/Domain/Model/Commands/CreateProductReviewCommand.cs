namespace practica_pc2.Work.Domain.Model.Commands;

public record CreateProductReviewCommand(string UserEmail, int Rating, string ReviewCriterion, string Comment);