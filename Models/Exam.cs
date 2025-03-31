using System.Collections.Generic;

namespace ExamManager.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Question { get; set; }
        public int? SelectedChoiceId { get; set; }
        public Choice? SelectedChoice { get; set; }

        public List<Choice> Choices { get; set; } = new();
    }
}
