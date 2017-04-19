using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMovies.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        private int movieId = 0;
        private string Uri = "http://mvcmovie20170415090257.azurewebsites.net/api/MoviesApi/";

        public EditPage(Movie movie)
        {
            InitializeComponent();

            TitleEntry.Text = movie.Title;
            ReleaseDateEntry.Text = movie.ReleaseDate.ToString();
            PriceEntry.Text = movie.Price.ToString();
            GenreEntry.Text = movie.Genre;
            RatingEntry.Text = movie.Rating;
            movieId = movie.ID;
        }

        private async void EditMovie_Clicked(object sender, EventArgs e)
        {
            var movie = new Movie
            {
                ID = movieId,
                Title = TitleEntry.Text,
                ReleaseDate = Convert.ToDateTime(ReleaseDateEntry.Text),
                Price = Convert.ToDecimal(PriceEntry.Text, CultureInfo.InvariantCulture),
                Genre = GenreEntry.Text,
                Rating = RatingEntry.Text
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(movie);

            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync(Uri + movie.ID, httpContent);
        }

        private async void DeleteMovie_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(Uri + movieId);

        }
    }
}
