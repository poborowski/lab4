using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Data;
using System;
using System.Linq;
namespace WebApplication3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication3Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplication3Context>>()))
            {
                // Look for any movies.
                if (context.BooksModel.Any())
                {
                    return;   // DB has been seeded
                }
                context.BooksModel.AddRange(
                    new BooksModel
                    {
                        Title = "W pustyni i w puszczy",
                        ReleaseDate = DateTime.Parse("1979-2-12"),
                        Category = "Przygodowe",
                        Price = 30M
                    },
                    new BooksModel
                    {
                        Title = "Harry Poter ",
                        ReleaseDate = DateTime.Parse("2007-3-13"),
                        Category = "Fantasy",
                        Price = 23M
                    },
                    new BooksModel
                    {
                        Title = "Pan Taduesz",
                        ReleaseDate = DateTime.Parse("1886-2-23"),
                        Category = "Poezja epicka",
                        Price = 15M
                    },
                    new BooksModel
                    {
                        Title = "Wesele",
                        ReleaseDate = DateTime.Parse("1859-4-15"),
                        Category = "Dramat",
                        Price = 12M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}