using SimpleNetWebBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleNetWebBusinessLayer
{
    public class BusinessLogic
    {
        public string GetBooksByAuthor(string authorName)
        {
            if (!authorName.Equals("tolkein", StringComparison.OrdinalIgnoreCase))
            {
                var notFound = new Author() { Id = 0, LastName = "Not Found", FirstName = $"{authorName} does not exist in the database" };
                return JsonSerializer.Serialize(notFound);
            }

            var authorTolkein = new Author() { Id = 100, LastName = "Tolkein", FirstName = "J. R. R." };

            var books = new List<Book>() {
                new Book() { Id = 2500, AuthorId = 100, Title = "The Hobbit" },
                new Book() { Id = 2501, AuthorId = 100, Title = "The Fellowship of the Ring" },
                new Book() { Id = 2502, AuthorId = 100, Title = "The Two Towers" },
                new Book() { Id = 2503, AuthorId = 100, Title = "The Return of the King" }
            };

            authorTolkein.Books = books;
            return JsonSerializer.Serialize(authorTolkein);
        }
    }
}
