namespace ExamManager.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string ChoiceLabel { get; set; }
        public string ChoiceText { get; set; }

        public Exam Exam { get; set; }
    }
}
