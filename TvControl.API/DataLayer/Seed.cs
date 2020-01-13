using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvControl.API.Models;

namespace TvControl.API.DataLayer
{
    public class Seed
    {
        public static void SeedGenres(DataContext context)
        {
            // check if entity is empty
            if (!context.Genres.Any())
            {
                var genresData = System.IO.File.ReadAllText("DataLayer/GengreSeed.json");

                // Convert data to genre objects
                var genres =JsonConvert.DeserializeObject<List<Genre>>(genresData);

                foreach (var genre in genres)
                {
                    context.Genres.Add(genre);
                }

                context.SaveChanges();
            }
        }
    }
}
