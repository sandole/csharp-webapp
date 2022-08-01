using System;
using Xunit;
using SimpleNetWebBusinessLayer.Models;
using System.Collections.Generic;
using SimpleNetWebBusinessLayer;
using System.Text.Json;
using Shouldly;

namespace SimpleNetWebAppTests
{
    public class TestBusinessLogic
    {
        private Author GetAuthorTolkein()
        {
            return new Author() { Id = 100, LastName = "Tolkein", FirstName = "J. R. R." };
        }

        private List<Book> GetBooks()
        {
            return new List<Book>() {
                new Book() { Id = 2500, AuthorId = 100, Title = "The Hobbit" },
                new Book() { Id = 2501, AuthorId = 100, Title = "The Fellowship of the Ring" },
                new Book() { Id = 2502, AuthorId = 100, Title = "The Two Towers" },
                new Book() { Id = 2503, AuthorId = 100, Title = "The Return of the King" }
            };
        }

        private Author GetAuthorNotFound(string authorName)
        {
            return new Author() { Id = 0, LastName = "Not Found", FirstName = $"{authorName} does not exist in the database" };
        }

        [Fact]
        public void TestGetAuthorGood()
        {
            var authorTolkein = GetAuthorTolkein();
            var books = GetBooks();
            authorTolkein.Books = books;

            var logicLayer = new BusinessLogic();
            var jsonAuthorTolkein = logicLayer.GetBooksByAuthor("tolkein");

            var retAuthor = JsonSerializer.Deserialize<Author>(jsonAuthorTolkein);

            retAuthor.ShouldNotBeNull();
            retAuthor.LastName.ShouldBe(authorTolkein.LastName);
            retAuthor.FirstName.ShouldBe(authorTolkein.FirstName);
            retAuthor.Books.ShouldNotBeNull();
            retAuthor.Books.Count.ShouldBeGreaterThanOrEqualTo(4);
            retAuthor.Books[0].Title.ShouldBe(authorTolkein.Books[0].Title);
            retAuthor.Books[1].Title.ShouldBe(authorTolkein.Books[1].Title);
            retAuthor.Books[2].Title.ShouldBe(authorTolkein.Books[2].Title);
            retAuthor.Books[3].Title.ShouldBe(authorTolkein.Books[3].Title);
        }

        [Fact]
        public void TestGetAuthorNotFound()
        {
            var authorBrooks = GetAuthorNotFound("Brooks");

            var logicLayer = new BusinessLogic();
            var jsonAuthorBrooks = logicLayer.GetBooksByAuthor("Brooks");

            var retAuthor = JsonSerializer.Deserialize<Author>(jsonAuthorBrooks);

            retAuthor.ShouldNotBeNull();
            retAuthor.LastName.ShouldBe(authorBrooks.LastName);
            retAuthor.FirstName.ShouldBe(authorBrooks.FirstName);
            retAuthor.Books.ShouldNotBeNull();
            retAuthor.Books.Count.ShouldBe(0);
        }
    }
}
