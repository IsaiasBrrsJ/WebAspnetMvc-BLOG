using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAspnet_.Models;
using WebAspnet_.Repository.Interfaces;
using WebAspnet_.ViewModel;

namespace WebAspnet_.Controllers
{

    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IRepositoryBase<User> _userRepository;

        private readonly IRepositoryBase<Post> _postRepository;

        public AdminController(
        ILogger<AdminController> logger,
        IRepositoryBase<User> userRepository,
        IRepositoryBase<Post> postRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
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

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var newUser = new User(Guid.NewGuid(), model.Name, model.Password, model.Email);
            await _userRepository.AddAsync(newUser);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logged(UserViewModel model)
        {
            var users = await _userRepository.GetAll();

            var userExist = users.Where(x => x.Email == model.Email && x.Password == model.Password).Count();

            if (userExist > 0)
                return View();


            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> NewPost()
        {
            await Task.Yield();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SavePost(PostViewModel model)
        {
            var id = Guid.NewGuid();
            var imageToByte = ConvertToBytes(model.Image);
            Console.WriteLine(model.Content);
            var newPost = new Post(id, model.Title, model.Resume, model.Content, imageToByte);

            await _postRepository.AddAsync(newPost);

            return RedirectToAction("NewPost", "Admin");
        }
        public async Task<IActionResult> AllPost()
        {
            var allPosts = await _postRepository.GetAll();
            return View(allPosts);
        }

        public async Task<IActionResult> UpdatePost(string id, string title, string resume, string content, IFormFile image)
        {
            var convertId = Guid.Parse(id);
            var imageToByte = ConvertToBytes(image);
            var getPosts = await _postRepository.GetAll();
            var post = getPosts.Where(p => p.Id == convertId).FirstOrDefault();

            post.Content = content;
            post.Resume = resume;
            post.Title = title;
            if (imageToByte != null)
                post.Image = imageToByte;


            await _postRepository.UpdateAsync(post);

            return RedirectToAction(nameof(AllPost));
        }
        private byte[] ConvertToBytes(IFormFile image)
        {
            if (image == null)
                return null;

            using (var inputStream = image.OpenReadStream())
            using (var stream = new MemoryStream())
            {
                inputStream.CopyTo(stream);
                return stream.ToArray();
            }
        }

    }
}