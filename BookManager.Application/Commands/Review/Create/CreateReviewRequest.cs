using MediatR;

namespace BookManager.Application.Commands.Review.Create;

public class CreateReviewRequest : IRequest<CreateReviewResponse>
{
    public Guid BookIdentifier { get; set; }
    public Guid UserIdentifier { get; set; }
    public int Rate { get; set; }
    public string Description { get; set; }
}