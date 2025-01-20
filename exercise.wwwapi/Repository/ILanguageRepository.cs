using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        Language Add(string name);
        Language Get(string name);
        IEnumerable<Language> GetAll();
        void Update(string name, LanguageDto model);

        Language Delete(string name);
    }
}
