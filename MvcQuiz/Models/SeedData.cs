using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcQuiz.Data;
//using MvcQuiz.Models;
using System;
using System.Linq;

namespace MvcQuiz.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcQuizContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcQuizContext>>()))
        {
            // Look for any movies.
            if (context.Quiz.Any())
            {
                return;   // DB has been seeded
            }
            context.Quiz.AddRange(
                new Quiz
                {
                    Title = "Suhak nightmare ",
                    ReleaseDate = DateTime.Parse("2024-8-16"),
                    Genre = "Sunung",
                    Price = 7.99M,
                    Rating = "R",
                },
                new Quiz
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "R",
                },
                new Quiz
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "R",

                },
                new Quiz
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "R",
                }
            );
            context.SaveChanges();
        }
    }
}