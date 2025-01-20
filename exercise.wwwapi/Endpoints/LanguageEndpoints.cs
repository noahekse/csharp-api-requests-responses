using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace workshop.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetLanguages);
            languages.MapPost("/", AddLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            var languages = repository.GetAll();
            return Results.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, string name)
        {
            return Results.Ok(repository.Add(name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, LanguageDto model)
        {
            try
            {
                repository.Update(name, model);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
            return Results.Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            try
            {
                var model = repository.Get(name);
                if (repository.Delete(name) != null) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Name = model.Name });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
