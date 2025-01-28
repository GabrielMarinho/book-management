using BookManager.Domain.Base;

namespace BookManager.Domain.Entities;

public class Author : Entity
{
    public string Name { get; set; }

    public long BookId { get; set; }
    public Book Book { get; set; }
}