using ShellNavigationIssue.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellNavigationIssue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        private readonly BookViewModel viewModel;

        public BookPage()
        {
            InitializeComponent();

            viewModel = (BookViewModel)BindingContext;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.OnAppearing();
        }
    }
}