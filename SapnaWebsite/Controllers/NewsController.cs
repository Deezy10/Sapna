using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SapnaWebsite.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SapnaWebsite.Controllers
{
    public class NewsController : Controller
    {
        private readonly EFDbContext _context;
        private IHostingEnvironment hostingEnv;

        public NewsController(EFDbContext context, IHostingEnvironment env)
        {
            _context = context;
            this.hostingEnv = env;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.SingleOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,DatePosted,Title,details,photo")] News news)
        {
            if (ModelState.IsValid)
            {
                if (news.photo != null && news.photo.Length > 0)
                {
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(news.photo.ContentDisposition);
                    string FilePath = parsedContentDisposition.FileName.Trim('"');
                    string FileExtension = Path.GetExtension(FilePath);
                    var uploadDir = hostingEnv.WebRootPath + $@"\Uploads\Media\";
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    var imageUrl = uploadDir + news.Title + FileExtension;

                    news.photo.CopyTo(new FileStream(imageUrl, FileMode.Create));
                }

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.SingleOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,DatePosted,Title,details,photo")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.SingleOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.SingleOrDefaultAsync(m => m.NewsId == id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
