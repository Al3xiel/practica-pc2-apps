namespace practica_pc2.Work.Interfaces.REST.Resources;

public record CreateProductReviewResource(string UserEmail, int Rating, string ReviewCriterion, string Comment);