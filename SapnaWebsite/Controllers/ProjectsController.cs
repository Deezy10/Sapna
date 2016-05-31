using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapnaWebsite.Models;
using SapnaWebsite.ViewModels.Projects;

namespace SapnaWebsite.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly EFDbContext _context;

        public ProjectsController(EFDbContext context)
        {
            _context = context;    
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var model = new CreateProjectViewModel();

            model.MembersList = _context.Members.ToList();
            model.SkillsList = _context.Skills.ToList();

            return View(model);
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectViewModel model)
        {
            Project project = new Project
            {
                Title = model.Title,
                Description = model.Description,
                DateStarted = model.DateStarted,
                DateCompleted = model.DateCompleted,
                TechnologiesUsed = model.TechnologiesUsed
            };

            if (ModelState.IsValid)
            {
                _context.Add(project);

                foreach (var item in model.SkillIds)
                {
                    ProjectSkill data = new ProjectSkill { SkillId = item, ProjectId = project.ProjectId };
                    _context.ProjectSkills.Add(data);
                }

                foreach (var item in model.Members)
                {
                    ProjectMember data = new ProjectMember { MemberId = item, ProjectId = project.ProjectId };
                    _context.ProjectMembers.Add(data);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            model.MembersList = _context.Members.ToList();
            model.SkillsList = _context.Skills.ToList();

            return View(model);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            EditProjectViewModel model = new EditProjectViewModel
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                DateCompleted = project.DateCompleted,
                DateStarted = project.DateStarted,
                Description = project.Description,
                MembersList = _context.Members.ToList(),
                SkillsList = _context.Skills.ToList(),
                TechnologiesUsed = project.TechnologiesUsed
            };

            return View(model);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProjectViewModel model)
        {
            if (id != model.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Project project = new Project
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    Description = model.Description,
                    DateStarted = model.DateStarted,
                    DateCompleted = model.DateCompleted,
                    TechnologiesUsed = model.TechnologiesUsed
                };

                try
                {
                    _context.Projects.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(m => m.ProjectId == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
