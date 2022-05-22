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
    }
}
