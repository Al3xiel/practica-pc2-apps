namespace practica_pc2.Work.Interfaces.REST.Resources;

public record  ProductReviewResource(int Id, string UserEmail, int Rating, string ReviewCriterion, string Comment, ProductResource Product);