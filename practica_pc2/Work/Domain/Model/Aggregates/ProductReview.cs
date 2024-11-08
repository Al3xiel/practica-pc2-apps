using practica_pc2.Work.Domain.Model.ValueObjects;

namespace practica_pc2.Work.Domain.Model.Aggregates;

public partial class ProductReview
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int Rating { get; set; }
    public EProductReviewCriterion ReviewCriterion { get; set; }
    public string Comment { get; set; }
    public int ProductId { get; private set; }
    public Product Product { get; internal set; }
    
    public ProductReview() { }
    
    public ProductReview(string userEmail, int rating, string reviewCriterion, string comment, int productId)
    {
        UserEmail = userEmail;
        Rating = rating;
        if (Enum.TryParse(reviewCriterion, true, out EProductReviewCriterion parsedCriterion))
        {
            ReviewCriterion = parsedCriterion;
        }
        else
        {
            throw new ArgumentException($"Invalid review criterion value: {reviewCriterion}");
        }
        Comment = comment;
        ProductId = productId;
    }
}