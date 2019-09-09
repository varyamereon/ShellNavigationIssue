using ShellNavigationIssue.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace ShellNavigationIssue.ViewModels
{
    [QueryProperty(nameof(SearchQuery), "name")]
    public class BookViewModel : BaseViewModel
    {
        private Book currentBook;

        public Book CurrentBook
        {
            get => currentBook;
            set => SetProperty(ref currentBook, value);
        }

        public string SearchQuery { get; set; }

        public async void OnAppearing()
        {
            // This breakpoint gets hit every time the Book page is navigated to. This should happen every time a search is carried out.
            // However it only gets navigated to from the About page. If the Books page is already open no navigation happens.
            // My question is is this by design? I always used this pattern in the past otherwise I would have to write some funky
            // code to get the search handler to work based on it knowing which page the user is already on.

            var books = await DataStore.GetItemsAsync().ConfigureAwait(false);

            CurrentBook = SearchQuery == null ? books.First() : books.FirstOrDefault(x => x.Name == Uri.UnescapeDataString(SearchQuery));
        }
    }
}
