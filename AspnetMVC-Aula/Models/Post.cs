using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspnet_.Models
{
    public class Post : Entity
    {


        public string Title { get; set; }
        public string Resume { get; set; }

        public string Content { get; set; }

        public DateTime DatePost { get; set; }

        public byte[] Image { get; set; }
        public Post(Guid id, string title, string resume, string content, byte[] image) : base(id)
        {
            Title = title;
            Resume = resume;
            Content = Content;
            Image = image;
            DatePost = DateTime.Now;
        }
    }
}