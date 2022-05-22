using Microsoft.AspNetCore.Mvc;
using WebAppRipetizione.Models;
using WebAppRipetizione.Models.Utils;

namespace WebAppRipetizione.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Post> posts = PostData.GetPosts();
            return View("HomePage", posts);
        }

        public IActionResult Details(int id)
        {
            Post postFound = null;
            foreach (Post post in PostData.GetPosts())
            {
                if (post.Id == id)
                {
                    postFound = post;
                    break;
                }
            }

                if(postFound != null)
                {
                    return View("Details", postFound);
                } else
                {
                    return NotFound($"Il post con l'Id {id} non è stato trovato");
                }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post nuovoPost)
        {
            if (!ModelState.IsValid)
            {
                return View("ErrorePost");
            }

            Post nuovoPostConId = new Post(PostData.GetPosts().Count, nuovoPost.Title, nuovoPost.Description, nuovoPost.Image);

            PostData.GetPosts().Add(nuovoPostConId);

            return RedirectToAction("HomePage");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPost");
        }
    }
}
