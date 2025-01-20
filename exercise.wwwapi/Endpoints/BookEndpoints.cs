using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.DTO.Language;

namespace workshop.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetBooks);
            books.MapPost("/", AddBook);
            books.MapDelete("/{id}", DeleteBook);
            books.MapPut("/{id}", UpdateBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            var books = repository.GetAll();
            return Results.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddBook(IBookRepository repository, BookDto model)
        {

            var addedBook = repository.Add(model);
            return Results.Ok(addedBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, BookDto model)
        {
            try
            {
                repository.Update(id, model);
               
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
            return Results.Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {
            try
            {
                var book = repository.Get(id);
                if (book == null)
                {
                    return Results.NotFound();
                }

                var deletedBook = repository.Delete(id);
                return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Book = deletedBook });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
