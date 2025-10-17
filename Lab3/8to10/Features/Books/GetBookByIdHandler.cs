using _8to10.Persistence;

namespace _8to10.Features.Books;

public class GetBookByIdHandler(BookManagementContext context)
{
    private readonly BookManagementContext _context = context;
    
    public async Task<IResult> Handle(GetBookByIdRequest request)
    {
        var book = await _context.Books.FindAsync(request.Id);
        return book == null ? Results.NotFound() : Results.Ok(book);
    }
}