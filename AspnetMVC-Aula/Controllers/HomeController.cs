using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAspnet_.Models;
using WebAspnet_.Repository.Interfaces;

namespace WebAspnet_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryBase<Post> _postRepository;
        public HomeController(ILogger<HomeController> logger, IRepositoryBase<Post> postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await _postRepository.GetAll();
            ViewBag.AllPosts = allPosts;
            return View(allPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [Route("postId")]
        public async Task<IActionResult> Post(Guid postId)
        {

            var getPost = await _postRepository.GetId(postId);

            var allPosts = await _postRepository.GetAll();

            ViewBag.AllPosts = allPosts;

            return View(getPost);
        }
        public async Task<IActionResult> SearchPost(string title)
        {
            var allPost = await _postRepository.GetAll();
            var postSelected = allPost.Where(p => p.Title.ToUpper().Contains(title.ToUpper())).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string title)
        {
            var allPost = await _postRepository.GetAll();
            var postsSelected = allPost.Where(p => p.Title.ToUpper().Contains(title.ToUpper())).ToList();

            ViewBag.AllPosts = postsSelected;

            return View(allPost);
        }
    }
}
