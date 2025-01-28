using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookManager.Application.Commands.Book.UpdateCover;

public class UpdateCoverRequest : IRequest<UpdateCoverResponse>
{
    public Guid Identifier { get; set; }
    public IFormFile File { get; set; }
}