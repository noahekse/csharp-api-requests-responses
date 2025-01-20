using exercise.wwwapi.Data;
using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languages;
        public LanguageRepository() 
        {
            _languages = new LanguageCollection();
        }

        public Language Add(string name)
        {
            return _languages.Add(name);
        }

        public Language Delete(string name)
        {
            return _languages.Remove(name);
        }

        public Language Get(string name)
        {
            return _languages.Get(name);
        }

        public IEnumerable<Language> GetAll()
        {
            return _languages.GetAll();
        }

        public void Update(string name, LanguageDto model)
        {
            _languages.Update(name, model);
        }
    }
}
