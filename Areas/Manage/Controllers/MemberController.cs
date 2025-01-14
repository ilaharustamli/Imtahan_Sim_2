using Imtahan_Sim_2.DAL;
using Imtahan_Sim_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imtahan_Sim_2.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MemberController : Controller
    {
        AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teamMembers = await _context.TeamMembers.Include(c => c.Position).ToListAsync();
            return View(teamMembers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
            return RedirectToAction("Index");



        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var teamMember = _context.TeamMembers.FirstOrDefault(c => c.Id == id);
            if (teamMember == null)
                return NotFound();
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var teamMember = _context.TeamMembers.FirstOrDefault(c => c.Id == id);
            return View(teamMember);
        }


    }
}