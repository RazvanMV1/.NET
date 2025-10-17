﻿using _8to10.Persistence;
using Microsoft.EntityFrameworkCore;

namespace _8to10.Features.Books;

public class DeleteBookHandler(BookManagementContext context)
{
    private readonly BookManagementContext _context = context;
    
    public async Task<IResult> Handle(DeleteBookRequest request)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.Id);
        if (book == null)
        {
            return Results.NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return Results.NoContent();
    }
}