using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Core.Entities;
using MoviesApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MoviesApp.SeedData
{
    public class DbInializer
    {
        public static  void seedData(IApplicationBuilder applicationBuilder, UserManager<AppUser> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                var roleExist = context.Roles.Where(x => x.Name == "Admin").SingleOrDefault();
                if(roleExist==null)
                {
                      var role = new IdentityRole();
                      role.Name = "Admin";
                       roleManager.CreateAsync(role).Wait();
                }
            }

            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                var adminExist = context.appUsers.Where(x => x.UserName == "Admin").SingleOrDefault();
                if (adminExist == null)
                {
                   
                    var user = new AppUser()
                    {
                        Id = "cf2da6d1-a82b-4a65-8ff6-f4480099b3f8",
                        UserName = "Admin",
                        Email = "Admin@gmail.com",
                        Address = "Poznan Poland",
                        PhoneNumber = "0048922889289"
                    };
                    context.appUsers.Add(user);

                    userManager.CreateAsync(user, "Admin123@").Wait();

                    userManager.AddToRoleAsync(user, "Admin").Wait();


                }
            }

            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                if(!context.Categories.Any())
                {
                    context.AddRange(
                        new Category() {
                            CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f8",
                         name= "Action"
                        },
                        new Category()
                        {
                            CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f7",
                            name = "Science Fiction"
                        },
                        new Category()
                        {
                            CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f3",
                            name = "Dramat"
                        },
                        new Category()
                        {
                            CategoryId = "bf2ra6d1-a62b-6a65-8ff6-f4480099b3f8",
                            name = "Adventure"
                        },
                        new Category()
                        {
                            CategoryId = "bf2ra4d1-a82b-6a65-8ff6-f4480099b3f8",
                            name = "Thriller"
                        },
                        new Category()
                        {
                            CategoryId = "bf2ra6d1-g82b-6a65-8ff6-f4480099b3f8",
                            name = "Documentary"
                        }
                        );
                    context.SaveChanges();

                    // add actors
                    var actor1 = new Actor {Id=Guid.NewGuid().ToString(), ActorName = "James McAvoy", ActorPicture = "JamesMcAvoy.png" };
                    var actor2 = new Actor {Id = Guid.NewGuid().ToString(), ActorName = "Michael Fassbender", ActorPicture = "MichaelFassbender.png" };
                    var actor3 = new Actor {Id = Guid.NewGuid().ToString(), ActorName = "Jennifer Lawrence", ActorPicture = "JenniferLawrence.png" };
                    var actor4 = new Actor {Id = Guid.NewGuid().ToString(), ActorName = "Sophie Turner", ActorPicture = "SophieTurner.png" };

                    var actor5 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Dwayne Johnson", ActorPicture = "DwayneJohnson.png" };
                    var actor6 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Jason Statham", ActorPicture = "JasonStatham.png" };
                    var actor7 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Idris Elba", ActorPicture = "IdrisElba.png" };
                    var actor8 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Vanessa Kirby", ActorPicture = "VanessaKirby.png" };

                    var actor9 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Ana de Armas", ActorPicture = "AnadeArmas.png" };
                    var actor10 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Rami Malek", ActorPicture = "RamiMalek.png" };
                    var actor11 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Daniel Craig", ActorPicture = "DanielCraig.png" };
                    var actor12 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Léa Seydoux", ActorPicture = "LéaSeydoux.png" };

                    var actor13 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Mark Wahlberg", ActorPicture = "MarkWahlberg.png" };
                    var actor14 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Anthony Hopkins", ActorPicture = "AnthonyHopkins.png" };
                    var actor15 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Laura Haddock", ActorPicture = "LauraHaddock.png" };
                    var actor16 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Isabela Merced", ActorPicture = "IsabelaMerced.png" };

                    var actor17 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Tom Hardy", ActorPicture = "TomHardy.png" };
                    var actor18 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Michelle Williams", ActorPicture = "MichelleWilliams.png" };
                    var actor19 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Riz Ahmed", ActorPicture = "RizAhmed.png" };
                    var actor20 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Jenny Slate", ActorPicture = "JennySlate.png" };

                    var actor21 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Paul Bettany", ActorPicture = "PaulBettany.png" };
                    var actor22 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Lucas Black", ActorPicture = "LucasBlack.png" };
                    var actor23 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Tyrese Gibson", ActorPicture = "TyreseGibson.png" };
                    var actor24 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Adrianne Palicki", ActorPicture = "AdriannePalicki.png" };

                    var actor25 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Liam Neeson", ActorPicture = "LiamNeeson.png" };
                    var actor26 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Kate Walsh", ActorPicture = "KateWalsh.png" };
                    var actor27 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Jai Courtney", ActorPicture = "JaiCourtney.png" };
                    var actor28 = new Actor { Id = Guid.NewGuid().ToString(), ActorName = "Herlin Navarro", ActorPicture = "HerlinNavarro.png" };




                    // add movies
                    context.AddRange(
                       new Movie
                       {
                           Id= Guid.NewGuid().ToString(),
                           Title = "X-Men: Dark Phoenix",
                           Description = "The X-Men. Protectors of peace. Jean Grey is one of the most" +
                                 " beloved X-Men. But when a mission goes wrong, Jean is exposed to a dark and" +
                                 " ancient power. ",
                           Picture = "X-MenDarkPhoenix.png",
                           MovieLink = "X-MenDarkPhoenix.mp4",
                           CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f7",
                           Actors=new List<Actor> { actor1,actor2,actor3,actor4}
                       },

                        new Movie
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "Fast & Furious Presents: Hobbs & Shaw",
                            Description = "Lawman Luke Hobbs (Dwayne The Rock Johnson) and outcast Deckard Shaw " +
                                            "(Jason Statham) form an unlikely alliance when a cyber-genetically" +
                                            " enhanced villain threatens the future of humanity",
                            Picture = "FastFuriousPresents.png",
                            MovieLink = "FastFuriousPresents.mp4",
                            CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f8",
                            Actors = new List<Actor> { actor5, actor6,actor7,actor8 }
                        },

                        new Movie
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = "No Time to Die",
                            Description = "Bond has left active service and is enjoying a tranquil life in Jamaica." +
                            " His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking " +
                            "for help. The mission to rescue a kidnapped scientist turns out to be far more treacherous" +
                            " than expected, leading Bond onto the trail of a mysterious villain armed with dangerous " +
                            "new technology.",
                            Picture = "NoTimetoDie.png",
                            MovieLink = "NoTimetoDie.mp4",
                            CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f8",
                            Actors = new List<Actor> { actor9, actor10, actor11,actor12 }
                        },
                         new Movie
                         {
                             Id = Guid.NewGuid().ToString(),
                             Title = "Transformers 5 The_Last_Knight",
                             Description = "Optimus Prime finds his dead home planet, Cybertron, in which " +
                             "he comes to find he was responsible for its destruction. He finds a way to bring" +
                             " Cybertron back to life, but in order to do so, Optimus needs to find an artifact" +
                             " that is on Earth.",
                             Picture = "Transformers-5.png",
                             MovieLink = "Transformers-5.mp4",
                             CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f7",
                             Actors = new List<Actor> { actor13, actor14, actor15, actor16 }
                         },
                          new Movie
                          {
                              Id = Guid.NewGuid().ToString(),
                              Title = "Venom",
                              Description = "After a faulty interview with the Life Foundation ruins his " +
                              "career, former reporter Eddie Brock's life is in pieces. Six months later, he " +
                              "comes across the Life Foundation again, and he comes into contact with an alien" +
                              " symbiote and becomes Venom, a parasitic antihero.",
                              Picture = "venom.png",
                              MovieLink = "venom.mp4",
                              CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f7",
                              Actors = new List<Actor> { actor17, actor18, actor19, actor20 }
                          },
                           new Movie
                           {
                               Id = Guid.NewGuid().ToString(),
                               Title = "Legion",
                               Description = "An out-of-the-way diner becomes the unlikely battleground for " +
                               "the survival of the human race. When God loses faith in humankind, he sends" +
                               " his legion of angels to bring on the Apocalypse. Humanity's only hope lies in" +
                               " a group of strangers trapped in a desert diner with the Archangel Michael (Bettany).",
                               Picture = "Legion.png",
                               MovieLink = "Legion.mp4",
                               CategoryId = "bf2ra6d1-a82b-6a65-8ff6-f4480099b3f3",
                               Actors = new List<Actor> { actor21, actor22, actor23, actor24 }
                           },
                           new Movie
                           {
                               Id = Guid.NewGuid().ToString(),
                               Title = "Honest Thief",
                               Description = "They call him the In-and-Out-Bandit because meticulous " +
                               "thief Tom Carter (Liam Neeson) has stolen $9 million from small-town " +
                               "banks while managing to keep his identity a secret. But after he falls" +
                               " in love with the bubbly Annie (Kate Walsh), Tom decides to make a fresh " +
                               "start by coming clean about his criminal past, only to be double-crossed " +
                               "by two ruthless FBI agents.",
                               Picture = "HonestThief.png",
                               MovieLink = "HonestThief.mp4",
                               CategoryId = "bf2ra4d1-a82b-6a65-8ff6-f4480099b3f8",
                               Actors = new List<Actor> { actor21, actor22, actor23, actor24 }
                           }

                       );
                    context.SaveChanges();
                }

            }

         
        }
    }
}
