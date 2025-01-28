using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Application.Enums;

public enum ApplicationError
{
    [Display(Name = "BOOK-NOT-FOUND")]
    [Description(description: "Book not found")]
    BookNotFound,
    
    [Display(Name = "BOOK-COVER-OVER-SIZE")]
    [Description(description: "Book cover is over size permited")]
    BookCoverFileOverSize,
    
    [Display(Name = "USER-NOT-FOUND")]
    [Description(description: "User not found")]
    UserNotFound
}