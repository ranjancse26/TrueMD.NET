using System.Collections.Generic;

namespace TrueMedLib
{
    public class Suggestion
    {
        public string suggestion { get; set; }
    }

    public class MedicineSuggestion
    {
        public List<Suggestion> suggestions { get; set; }
    }
}
