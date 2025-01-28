using BookManager.Domain.Base;

namespace BookManager.Domain.Entities;

public class Review : Entity
{
    public int Rate { get; set; }
    public string Description { get; set; }

    public User User { get; set; }
    public Book Book { get; set; }
}