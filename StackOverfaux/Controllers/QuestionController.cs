using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackOverfaux.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverfaux.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Question> allQuestions = _context.Questions.ToList();
            return View(allQuestions);
        }

        public IActionResult Details(int id)
        {
            var question = _context.Questions.SingleOrDefault(q => q.QuestionId == id);
            return View(question);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            question.Date = DateTime.Now;
            _context.Add(question);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Question question)
        {
            _context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisQuestion = _context.Questions.FirstOrDefault(Questions => Questions.QuestionId == id);
            _context.Remove(thisQuestion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
