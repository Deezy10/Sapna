using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapnaWebsite.Models;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SapnaWebsite.Controllers
{
    public class SkillsController : BaseController
    {
        private readonly EFDbContext _context;
        private IHostingEnvironment hostingEnv;

        public SkillsController(EFDbContext context, IHostingEnvironment env)
        {
            _context = context;
            this.hostingEnv = env;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skills.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.SingleOrDefaultAsync(m => m.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Logo,Name")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                if (skill.Logo != null && skill.Logo.Length > 0)
                {
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(skill.Logo.ContentDisposition);
                    string FilePath = parsedContentDisposition.FileName.Trim('"');
                    string FileExtension = Path.GetExtension(FilePath);
                    var uploadDir = hostingEnv.WebRootPath + $@"\Uploads\Skills\";
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    var imageUrl = uploadDir + skill.Name + FileExtension;

                    skill.Logo.CopyTo(new FileStream(imageUrl, FileMode.Create));
                }

                _context.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.SingleOrDefaultAsync(m => m.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillId,Logo,Name")] Skill skill)
        {
            if (id != skill.SkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.SkillId))
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
            return View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.SingleOrDefaultAsync(m => m.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(m => m.SkillId == id);
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.SkillId == id);
        }
    }
}
