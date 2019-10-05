using System;

namespace Blog.Api.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreationDateTime { get; set; }
    }
}