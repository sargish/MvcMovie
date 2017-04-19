using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Net.Http.Headers;

namespace MyMovies.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private string Uri = "http://mvcmovie20170415090257.azurewebsites.net/api/MoviesApi";

        public AddPage()
        {
            InitializeComponent();
        }

        public async Task AddMovieAsync()
        {
            var httpClient = new HttpClient();

            var title = TitleEntry.Text;
            var dt = ReleaseDateEntry.Text;
            DateTime releaseDate = Convert.ToDateTime(dt);
            var p = PriceEntry.Text;
            decimal price = Convert.ToDecimal(p, CultureInfo.InvariantCulture);
            var genre = GenreEntry.Text;
            var rating = RatingEntry.Text;

            var movie = new Movie
            {
                Title = title,
                ReleaseDate = releaseDate,
                Price = price,
                Genre = genre,
                Rating = rating
            };

            var json = JsonConvert.SerializeObject(movie);

            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(Uri, httpContent);

        }

        private async void AddMovie_Clicked(object sender, EventArgs e)
        {
            await AddMovieAsync();
        }
    }
}

