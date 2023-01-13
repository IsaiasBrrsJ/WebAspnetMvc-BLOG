using WebAspnet_.Models;
using WebAspnet_.Repository.Base;
using WebAspnet_.Repository.Interfaces;

namespace WebAspnet_.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context) { }

    }
}