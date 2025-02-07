using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AquariumForum.Data;
using AquariumForum.Models;

public class HomeController : Controller
{
    private readonly AquariumForumContext _context;

    public HomeController(AquariumForumContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
            var discussions = await _context.Discussion
            .Include(d => d.Comments)
            .OrderByDescending(d => d.CreateDate)
            .ToListAsync();

        return View(discussions);
    }
    public async Task<IActionResult> GetDiscussion(int id)
    {
        var discussion = await _context.Discussion
            .Include(d => d.Comments)
            .FirstOrDefaultAsync(d => d.DiscussionId == id);
        if (discussion == null)
        {
            return NotFound();
        }

        return View(discussion);
    }
}
