using System;

namespace Blog.Api.Domain.Entities
{
    public class Article
    {
        public int Id { get; protected set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string Author { get; private set; }

        public DateTimeOffset CreationDateTime { get; private set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
            CreationDateTime = DateTimeOffset.UtcNow;
        }
    }
}