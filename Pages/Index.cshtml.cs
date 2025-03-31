using ExamManager.Data;
using ExamManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Exam> ExamList { get; set; } = new();

        public async Task OnGetAsync()
        {
            ExamList = await _context.Exams
                .Include(e => e.Choices)
                .OrderBy(e => e.Number)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var exams = await _context.Exams.ToListAsync();

            foreach (var exam in exams)
            {
                string fieldName = $"SelectedChoice_{exam.Id}";
                if (Request.Form.TryGetValue(fieldName, out var selectedValue))
                {
                    if (int.TryParse(selectedValue, out int choiceId))
                    {
                        exam.SelectedChoiceId = choiceId;
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var exam = await _context.Exams
                .Include(e => e.Choices)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exam != null)
            {
                exam.SelectedChoiceId = null;
                await _context.SaveChangesAsync();

                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();

                var exams = await _context.Exams.OrderBy(e => e.Number).ToListAsync();
                for (int i = 0; i < exams.Count; i++)
                {
                    exams[i].Number = i + 1;
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
