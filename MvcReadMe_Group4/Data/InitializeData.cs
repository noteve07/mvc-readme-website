using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcReadMe_Group4.Data;
using MvcReadMe_Group4.Models;

namespace MvcReadMe_Group4.Data
{
    public static class InitializeData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcReadMe_Group4Context(
                serviceProvider.GetRequiredService<DbContextOptions<MvcReadMe_Group4Context>>()))
            {
                // delete existing data
                if (context.Books.Any())
                {
                    return; /* DEBUG */
                    context.Books.RemoveRange(context.Books);
                    context.SaveChanges();
                }

                // delete existing data
                if (context.Users.Any())
                {
                    return; /* DEBUG */
                    context.Users.RemoveRange(context.Users);
                    context.SaveChanges();
                }

                // seed sample data
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Python Crash Course",
                        Author = "Eric Matthes",
                        Category = "Programming",
                        Description = "A hands-on, project-based introduction to programming with Python.",
                        ISBN = "9781593279288",
                        FilePath = "/assets/books/python-crash-course.pdf",
                        CoverImagePath = "/assets/img/covers/python-crash-course-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "Automate The Boring Stuff with Python",
                        Author = "Al Sweigart",
                        Category = "Programming",
                        Description = "Learn to automate everyday tasks with Python and save time.",
                        ISBN = "9781593275990",
                        FilePath = "/assets/books/automate-the-boring-stuff-with-python.pdf",
                        CoverImagePath = "/assets/img/covers/automate-the-boring-stuff-with-python-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "The Atomic Habits",
                        Author = "James Clear",
                        Category = "Self-Help",
                        Description = "An easy & proven way to build good habits and break bad ones.",
                        ISBN = "9780735211292",
                        FilePath = "/assets/books/atomic-habits.pdf",
                        CoverImagePath = "/assets/img/covers/atomic-habits-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "The Courage to be Disliked",
                        Author = "Ichiro Kishimi & Fumitake Koga",
                        Category = "Self-Help",
                        Description = "A philosophical dialogue about the courage to live freely and create your own life.",
                        ISBN = "9781608802003",
                        FilePath = "/assets/books/the-courage-to-be-disliked.pdf",
                        CoverImagePath = "/assets/img/covers/the-courage-to-be-disliked-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "The Midnight Library",
                        Author = "Matt Haig",
                        Category = "Fiction",
                        Description = "A woman finds herself in a library between life and death, where every book represents a different life she could have lived.",
                        ISBN = "9780525559474",
                        FilePath = "/assets/books/the-midnight-library.pdf",
                        CoverImagePath = "/assets/img/covers/the-midnight-library-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "The Hobbit",
                        Author = "J.R.R. Tolkien",
                        Category = "Fiction",
                        Description = "A young hobbit's journey to win a treasure guarded by a dragon, and the friends he makes along the way.",
                        ISBN = "9780345339683",
                        FilePath = "/assets/books/the-hobbit.pdf",
                        CoverImagePath = "/assets/img/covers/the-hobbit-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "Cosmos",
                        Author = "Carl Sagan",
                        Category = "Science",
                        Description = "A personal voyage through the universe, from the birth of the cosmos to life on Earth.",
                        ISBN = "9780345539434",
                        FilePath = "/assets/books/cosmos.pdf",
                        CoverImagePath = "/assets/img/covers/cosmos-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "Quantum Supremacy",
                        Author = "Michio Kaku",
                        Category = "Science",
                        Description = "Exploring the future of quantum computing and its world-changing potential.",
                        ISBN = "9780525536687",
                        FilePath = "/assets/books/quantum-supremacy.pdf",
                        CoverImagePath = "/assets/img/covers/quantum-supremacy-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "Man's Search for Meaning",
                        Author = "Viktor E. Frankl",
                        Category = "Philosophy",
                        Description = "A psychiatrist's personal experience of life in Nazi concentration camps and the search for meaning in suffering.",
                        ISBN = "9780807014295",
                        FilePath = "/assets/books/man-search-for-meaning.pdf",
                        CoverImagePath = "/assets/img/covers/man-search-for-meaning-cover.jpg",
                        NumberOfReads = 0
                    },
                    new Book
                    {
                        Title = "Philosophy 101",
                        Author = "Paul Kleinman",
                        Category = "Philosophy",
                        Description = "From Plato and Socrates to ethics and metaphysics, an essential primer on philosophical thought.",
                        ISBN = "9781440541763",
                        FilePath = "/assets/books/philosophy-101.pdf",
                        CoverImagePath = "/assets/img/covers/philosophy-101-cover.jpg",
                        NumberOfReads = 0
                    }
                );


                // seed sample data for users
                context.Users.AddRange(
                    new User
                    {
                        UserName = "Admin",
                        Password = "admin_123",
                        Role = "Admin"
                    },
                    new User
                    {
                        UserName = "nicko_712",
                        Password = "tralaleo23",
                    },
                    new User
                    {
                        UserName = "jheris456",
                        Password = "crocodillo45"
                    },
                    new User
                    {
                        UserName = "reinald.42",
                        Password = "bananini789"
                    },
                    new User
                    {
                        UserName = "pythonic712",
                        Password = "skibidi99"
                    },
                    new User
                    {
                        UserName = "tech_guru_99",
                        Password = "potatohead11"
                    },
                    new User
                    {
                        UserName = "coderx_77",
                        Password = "zombietaco21"
                    },
                    new User
                    {
                        UserName = "skywalker001",
                        Password = "sharknado42",
                        Role = "User"
                    },
                    new User
                    {
                        UserName = "dreamer_88",
                        Password = "spongebobrocks23"
                    },
                    new User
                    {
                        UserName = "pixelwizard_12",
                        Password = "clownfish@201"
                    },
                    new User
                    {
                        UserName = "ninja_42",
                        Password = "fanumtax77"
                    },
                    new User
                    {
                        UserName = "binarybee99",
                        Password = "mechacode32"
                    },
                    new User
                    {
                        UserName = "cloudybrain",
                        Password = "drizzledev88"
                    },
                    new User
                    {
                        UserName = "gadgetqueen",
                        Password = "robochic11"
                    },
                    new User
                    {
                        UserName = "bytebrawler",
                        Password = "matrixrush45"
                    },
                    new User
                    {
                        UserName = "cosmicdevv",
                        Password = "plutocoder69"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
