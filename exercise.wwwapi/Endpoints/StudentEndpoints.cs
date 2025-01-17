using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel.Student;
using Microsoft.AspNetCore.Mvc;


namespace workshop.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigurePetEndpoint(this WebApplication app)
        {
            var pets = app.MapGroup("students");

            pets.MapGet("/", GetStudents);
            pets.MapPost("/", AddStudent);
            pets.MapDelete("/{name}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var students = repository.GetAll();
            return Results.Ok(students);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, StudentRequest model)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            repository.Add(student);

            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string name, StudentRequest model)
        {
            Student student = repository.Update(name, model);
           

            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteStudent(IStudentRepository repository, string name)
        {
            try
            {
                var model = repository.Get(name);
                if (repository.Delete(name)) return Results.Ok(new { When=DateTime.Now, Status="Deleted", FirstName=model.FirstName, LastName=model.LastName});
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
