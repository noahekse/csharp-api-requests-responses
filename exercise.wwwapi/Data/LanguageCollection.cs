using exercise.wwwapi.DTO.Language;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(string name)
        {
            Language newLanguage = new Language(name);
            languages.Add(newLanguage);

            return newLanguage;
        }

        public Language Remove(string name)
        {
            Language language = languages.FirstOrDefault(s => s.Name == name);
            languages.Remove(language);

            return language;
        }

        public Language Get(string name)
        {
            return languages.FirstOrDefault(s => s.Name == name);
        }

        public void Update(string name, LanguageDto model)
        {
            languages.FirstOrDefault(s => s.Name == name).Name = model.Name;
        }



        public List<Language> GetAll()
        {
            return languages.ToList();
        }

        public List<Language> Languages { get { return languages; } }


    }
}
