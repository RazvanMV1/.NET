﻿using _8to10.Persistence;
using Microsoft.EntityFrameworkCore;
using _8to10.Validators;

namespace _8to10.Features.Books;

public class UpdateBookHandler(BookManagementContext context)
{
    private readonly BookManagementContext _context = context;

    public async Task<IResult> Handle(UpdateBookRequest request)
    {
        var validator = new UpdateBookValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }
        
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.Id);
        if (book is null)
            return Results.NotFound();
        
        var updatedBook = book with
        {
            Title = request.Title,
            Author = request.Author,
            YearPublished = request.YearPublished
        };
        
        _context.Entry(book).CurrentValues.SetValues(updatedBook);
        await _context.SaveChangesAsync();

        return Results.Ok(updatedBook);
    }
}