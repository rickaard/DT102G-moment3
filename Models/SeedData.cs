using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using moment3.Data;
using moment3.Models;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAlbumContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAlbumContext>>()))
            {
                // Look for any albums.
                if (context.Album.Any())
                {
                    return;   // DB has been seeded
                }

                context.Album.AddRange(
                    new Album
                    {
                        Title = "Brothers In Arms",
                        Artist = new Artist { FullName = "Dire Straits" },
                        ReleaseDate = DateTime.Parse("1985-2-12"),
                        AmountOfSongs = 9,
                        PlayTime = 55.00
                    },
                    new Album
                    {
                        Title = "Illusioner",
                        Artist = new Artist { FullName = "Håkan Hellström" },
                        ReleaseDate = DateTime.Parse("2018-2-12"),
                        AmountOfSongs = 10,
                        PlayTime = 42.00
                    },
                    new Album
                    {
                        Title = "Anthem Of The PeaceFul Army",
                        Artist = new Artist { FullName = "Greta Van Fleet" },
                        ReleaseDate = DateTime.Parse("2018-2-12"),
                        AmountOfSongs = 11,
                        PlayTime = 49.00
                    },
                    new Album
                    {
                        Title = "Vi var där (Live)",
                        Artist = new Artist { FullName = "Lars Winnerbäck" },
                        ReleaseDate = DateTime.Parse("2017-2-12"),
                        AmountOfSongs = 38,
                        PlayTime = 172.00
                    }
                );
                context.SaveChanges();
            }
        }
    }
}