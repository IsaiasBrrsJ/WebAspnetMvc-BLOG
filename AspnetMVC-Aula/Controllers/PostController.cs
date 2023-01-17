using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAspnet_.Models;
using WebAspnet_.Repository.Interfaces;

namespace WebAspnet_.Controllers
{

    public class PostController : Controller
    {
        private readonly IRepositoryBase<Post> _postRepository;
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, IRepositoryBase<Post> postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public async Task<IActionResult> GetPost(Guid postId, string title = "")
        {
            var allPost = await _postRepository.GetAll();
            var getPost = allPost.Where(p => p.Id == postId).FirstOrDefault();

            if (title is null)
            {
                ViewBag.AllPosts = allPost;
            }
            else
            {
                var postSelected = allPost.Where(p => p.Title.ToUpper().Contains(title.ToUpper())).ToList();

                ViewBag.AllPosts = postSelected;
            }

            return View(getPost);
        }
    }
}