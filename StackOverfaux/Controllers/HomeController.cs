using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackOverfaux.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace StackOverfaux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Question> allQuestions = _context.Questions.Include(questions => questions.User).ToList();

            return View(allQuestions);
        }
        
      

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpVote(Question question)
        {
            question.Vote("up");
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
