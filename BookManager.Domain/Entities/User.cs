using BookManager.Domain.Base;

namespace BookManager.Domain.Entities;

public class User : Entity
{
    public string Email { get; set; }
    public string Name { get; set; }

    public IEnumerable<Review> Reviews { get; set; }
}