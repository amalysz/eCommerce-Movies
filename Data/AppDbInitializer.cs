using eMovies.Data.Static; 
using eMovies.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                // Media
                if (!context.Medias.Any())
                {
                    context.Medias.AddRange(new List<Media>()
                    {
                        new Media()
                        {
                            Name = "Blu-ray"
                        },
                        new Media()
                        {
                            Name = "DVD"
                        },
                        new Media()
                        {
                            Name = "VHS"
                        }
                    });
                    context.SaveChanges();
                }

                // Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Harrison Ford",
                            Info = "Harrison was born on July 13, 1942 in Chicago, Illinois. Ford was a Boy Scout, achieving the second-highest rank of Life Scout.",
                            ProfilePictureURL = "/images/harrison_ford.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Tommy Lee Jones",
                            Info = "Tommy Lee Jones was born September 15, 1946 in San Saba, Texas.",
                            ProfilePictureURL = "/images/tommy_lee_jones.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Morgan Freeman",
                            Info = "Morgan was born on June 1, 1937 in Memphis, Tennessee. The young Freeman attended Los Angeles City College before serving several years in the US Air Force as a mechanic between 1955 and 1959.",
                            ProfilePictureURL = "/images/morgan_freeman.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Tim Robbins",
                            Info = "Born in West Covina, California, but raised in New York City, Timothy Francis Robbins was born on October 16, 1958.",
                            ProfilePictureURL = "/images/tim_robbins.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Javier Bardem",
                            Info = "Javier Bardem belongs to a family of actors that have been working on films since the early days of Spanish cinema. He was born in Las Palmas de Gran Canaria, Spain on March 1, 1969.",
                            ProfilePictureURL = "/images/javier_bardem.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Angelina Jolie",
                            Info = "Born in USA.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Jim Carrey",
                            Info = "Born in Canada.",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                // Directors
                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            FullName = "Andrew Davis",
                            Info = "Davis was born on the south side of Chicago, Illinois on November 21, 1946.",
                            ProfilePictureURL = "/images/andrew_davis.jpg"
                        },
                        new Director()
                        {
                            FullName = "Frank Darabont",
                            Info = "Frank Darabont was born in a refugee camp in 1959 in Montbeliard, France, the son of Hungarian parents who had fled Budapest during the failed 1956 Hungarian revolution.",
                            ProfilePictureURL = "/images/frank_darabont.jpg"
                        },
                        new Director()
                        {
                            FullName = "Joel Coen",
                            Info = "Joel Daniel Coen is an American filmmaker who regularly collaborates with his younger brother Ethan. Joel Daniel Coen was born on November 29, 1954 in St. Louis Park, Minnesota.",
                            ProfilePictureURL = "/images/joel_coen.jpg"
                        },
                        new Director()
                        {
                            FullName = "Steven Spielberg",
                            Info = "Steven Allan Spielberg was born in Cincinnati, Ohio.",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Director()
                        {
                            FullName = "Mell Gibson",
                            Info = "Mel Columcille Gerard Gibson was born January 3, 1956 in Peekskill, New York, USA. Mel and his family moved to Australia in the late 1960s, settling in New South Wales, where Mel's paternal grandmother, contralto opera singer Eva Mylott, was born.",
                            ProfilePictureURL = "/images/mell_gibson.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                // Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "The Fugitive",
                            Description = "Dr. Richard Kimble, unjustly accused of murdering his wife, must find the real killer while being the target of a nationwide manhunt.",
                            Price = 19.99,
                            ImageURL = "/images/the_fugitive.jpg",
                            Year = 1993,
                            Quantity = 10,
                            MediaId = 2,
                            DirectorId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            Price = 19.99,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            Year = 1994,
                            Quantity = 0,
                            MediaId = 2,
                            DirectorId = 2,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "No Country for Old Men",
                            Description = "Violence and mayhem ensue after a hunter stumbles upon a drug deal gone wrong and more than two million dollars in cash near the Rio Grande.",
                            Price = 24.99,
                            ImageURL = "http://dotnethow.net/images/movies/movie-2.jpeg",
                            Year = 2007,
                            Quantity = 10,
                            MediaId = 1,
                            DirectorId = 3,
                            MovieCategory = MovieCategory.Crime
                        } 
                    });
                    context.SaveChanges();
                }

                // Actors & Movies
                if (!context.Movies_Actors.Any())
                {
                    context.Movies_Actors.AddRange(new List<Movie_Actor>()
                    {
                        new Movie_Actor()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Movie_Actor()
                        {
                            ActorId = 2,
                            MovieId = 1
                        },
                        new Movie_Actor()
                        {
                            ActorId = 3,
                            MovieId = 2
                        },                        
                         new Movie_Actor()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },
                        new Movie_Actor()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                         new Movie_Actor()
                        {
                            ActorId = 5,
                            MovieId = 3
                        }
                    });
                    context.SaveChanges();
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminEmail = "admin@emovies.com";

                var admin = await userManager.FindByEmailAsync(adminEmail);
                if (admin == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdmin, "AdminP@ss1");
                    await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }


                string userEmail = "user@emovies.com";

                var user = await userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "user",
                        Email = userEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newUser, "UserP@ss1");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);
                }
            }
        }
    }
}
