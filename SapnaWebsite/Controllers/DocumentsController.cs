using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapnaWebsite.Models;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace SapnaWebsite.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly EFDbContext _context;
        private IHostingEnvironment hostingEnv;

        public DocumentsController(EFDbContext context, IHostingEnvironment env)
        {
            _context = context;
            this.hostingEnv = env;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documents.ToListAsync());
        }


        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,DatePosted,Ducument,Name")] Document document)
        {
            if (ModelState.IsValid)
            {
                if (document.Ducument != null && document.Ducument.Length > 0)
                {
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(document.Ducument.ContentDisposition);
                    string FilePath = parsedContentDisposition.FileName.Trim('"');
                    string FileExtension = Path.GetExtension(FilePath);
                    var uploadDir = hostingEnv.WebRootPath + $@"\Uploads\Documents\";
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    var imageUrl = uploadDir + document.Name + FileExtension;

                    document.Ducument.CopyTo(new FileStream(imageUrl, FileMode.Create));
                }
                    _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.SingleOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,DatePosted,Ducument,Name")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentId))
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
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.SingleOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.SingleOrDefaultAsync(m => m.DocumentId == id);
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}
