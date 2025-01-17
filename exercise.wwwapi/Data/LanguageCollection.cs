using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(Language language)
        {
            languages.Add(language);

            return language;
        }

        public Language Remove(string name)
        {
            Language language = languages.FirstOrDefault(s => s.Name == name);
            languages.Remove(language);

            return language;
        }

        public List<Language> Languages { get { return languages; } }


    }
}
