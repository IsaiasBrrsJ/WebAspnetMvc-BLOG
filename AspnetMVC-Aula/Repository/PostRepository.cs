using WebAspnet_.Models;
using WebAspnet_.Repository.Base;
using WebAspnet_.Repository.Interfaces;

namespace WebAspnet_.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context) { }
    }
}