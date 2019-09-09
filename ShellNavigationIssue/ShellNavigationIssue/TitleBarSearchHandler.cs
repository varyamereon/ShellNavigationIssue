using ShellNavigationIssue.Models;
using ShellNavigationIssue.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellNavigationIssue
{
    public class TitleBarSearchHandler : SearchHandler
    {
        private string searchQuery = "";

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            searchQuery = newValue;
        }

        protected override async void OnQueryConfirmed()
        {
            base.OnQueryConfirmed();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                if ((await DependencyService.Get<IDataStore<Book>>().GetItemsAsync().ConfigureAwait(false)).FirstOrDefault(x => x.Name.Contains(searchQuery, StringComparison.InvariantCultureIgnoreCase)) is Book found)
                {
                    // This line to delay is certainly a seperate bug, an exception is raised if it is not included.
                    await Task.Delay(1000);

                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync($"//books?name={found.Name}");
                    });
                }
            }
        }
    }
}
