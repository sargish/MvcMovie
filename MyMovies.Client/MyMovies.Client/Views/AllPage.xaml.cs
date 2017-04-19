using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMovies.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllPage : ContentPage
    {
        private string Uri = "http://mvcmovie20170415090257.azurewebsites.net/api/MoviesApi";
        public AllPage()
        {
            InitializeComponent();

            DownloadMoviesAsync();
        }

        private async Task DownloadMoviesAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Uri);

            var movies = JsonConvert.DeserializeObject<List<Movie>>(json);

            MoviesListView.ItemsSource = movies;

        }

        private async void MoviesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var movie = e.Item as Movie;

            if(movie != null)
            {
                await Navigation.PushModalAsync(new EditPage(movie));
            }
        }
    }
}
