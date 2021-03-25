using System;
using System.Net.Http;
using System.Windows.Input;
using MyReadBooks.Models;
using MyReadBooks.ViewModels.Helpers;
using Newtonsoft.Json;
using Prism.Commands;

namespace MyReadBooks.ViewModels
{
    public class NewBookVM
    {
        public ICommand SearchCommand { get; set; }

        public NewBookVM()
        {
            SearchCommand = new DelegateCommand<string>(GetSearchResults);
        }

        private async void GetSearchResults(string query)
        {
            using(HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={query}&key={Constants.GOOGLE_BOOKS_API_KEY}");

                var data = JsonConvert.DeserializeObject<BooksAPI>(result);
            }
        }
    }
}
