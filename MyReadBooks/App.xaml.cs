using System;
using MyReadBooks.ViewModels;
using MyReadBooks.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyReadBooks
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/BooksPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BooksPage, BooksVM>();
            containerRegistry.RegisterForNavigation<NewBookPage, NewBookVM>();
            containerRegistry.RegisterForNavigation<BookDetailsPage, BookDetailsVM>();
        }
    }
}
