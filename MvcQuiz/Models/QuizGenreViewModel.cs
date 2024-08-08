using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcQuiz.Models
{
    public class QuizGenreViewModel
    {
        public List<Quiz>? Quizzes { get; set; }
        public SelectList? Genres { get; set; }
        public string? QuizGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
