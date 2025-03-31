using ExamManager.Data;
using ExamManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamManager.Pages
{
    public class AddExamModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddExamModel(AppDbContext context) => _context = context;

        [BindProperty]
        public string Question { get; set; }

        [BindProperty]
        public List<string> Choices { get; set; } = new();

        public void OnGet()
        {
            if (Choices.Count != 4)
            {
                Choices = new List<string> { "", "", "", "" };
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Question) || Choices.Count != 4 || Choices.Any(string.IsNullOrWhiteSpace))
            {
                ModelState.AddModelError("", "กรุณากรอกคำถามและตัวเลือกให้ครบ");
                return Page();
            }

            var exam = new Exam
            {
                Question = Question,
                Number = await _context.Exams.CountAsync() + 1
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            for (int i = 0; i < 4; i++)
            {
                var choice = new Choice
                {
                    ChoiceLabel = $"ข้อที่ {i + 1}",
                    ChoiceText = Choices[i],
                    ExamId = exam.Id
                };

                _context.Choices.Add(choice);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
