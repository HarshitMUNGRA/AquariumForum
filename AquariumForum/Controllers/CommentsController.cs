using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AquariumForum.Data;
using AquariumForum.Models;

namespace AquariumForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly AquariumForumContext _context;

        public CommentsController(AquariumForumContext context)
        {
            _context = context;
        }
        public IActionResult Create(int discussionId)
        {
            var comment = new Comment { DiscussionId = discussionId };
            return View(comment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscussionId,Content")] Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                TempData["Error"] = "Comment cannot be empty!";
                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
            }

            comment.CreateDate = DateTime.Now;
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
        }
    }
}
