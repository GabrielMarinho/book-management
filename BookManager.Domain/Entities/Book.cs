using BookManager.Domain.Base;
using BookManager.Domain.Enums;

namespace BookManager.Domain.Entities;

public class Book : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }

    public string Publishing { get; set; }
    public BookGenre Genre { get; set; }
    public DateTime PublishedAt { get; set; }
    public int TotalPages { get; set; }
    public decimal Average { get; set; }
    public string BookCover { get; set; }

    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}