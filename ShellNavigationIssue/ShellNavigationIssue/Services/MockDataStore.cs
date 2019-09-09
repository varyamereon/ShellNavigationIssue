using ShellNavigationIssue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShellNavigationIssue.Services
{
    public class MockDataStore : IDataStore<Book>
    {
        readonly List<Book> books;

        public MockDataStore()
        {
            books = new List<Book>();
            var mockBooks = new List<Book>
            {
                new Book{Id = Guid.NewGuid().ToString(),Name="Harry Potter", Author="J K Rowling"},
                new Book{Id = Guid.NewGuid().ToString(),Name="Lord of the Rings", Author="JRR Tolkein"},
                new Book{Id = Guid.NewGuid().ToString(),Name="Cloud Atlas", Author="David Mitchell"},
                new Book{Id = Guid.NewGuid().ToString(),Name="Dracula", Author="Bram Stoker"},
                //new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            foreach (var book in mockBooks)
            {
                books.Add(book);
            }
        }

        public async Task<bool> AddItemAsync(Book book)
        {
            books.Add(book);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Book book)
        {
            var oldBook = books.Where((Book arg) => arg.Id == book.Id).FirstOrDefault();
            books.Remove(oldBook);
            books.Add(book);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldBook = books.Where((Book arg) => arg.Id == id).FirstOrDefault();
            books.Remove(oldBook);

            return await Task.FromResult(true);
        }

        public async Task<Book> GetItemAsync(string id) => await Task.FromResult(books.FirstOrDefault(s => s.Id == id));

        public async Task<IEnumerable<Book>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(books);
    }
}