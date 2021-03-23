


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MoviesApp.Controllers
{
  
    public class MovieController : AbstractAPIController
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IActorRepo _actorRepo;

        public MovieController(IMovieRepo movieRepo, IActorRepo actorRepo)
        {
            _movieRepo = movieRepo;
            _actorRepo = actorRepo;
        }

        [HttpGet("GetMoviesList")]
        public IEnumerable<MovieListingModel> Movies()
        {
            var model = _movieRepo.GetAllMovies();
            var MoviesList = _movieRepo.GetAllMovies().Select(m => new MovieListingModel
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Picture = m.Picture,
                CategoryId = m.CategoryId,
                MovieLink = m.MovieLink,
                Actors = m.Actors.Select(a => new ActorListingModel { 
                 Id=a.Id,
                 ActorName=a.ActorName,
                 ActorPicture=a.ActorPicture
                })
            }) ;
         

            return MoviesList;
        }
        [HttpGet("{id}")]
        public async Task<MovieIndexModel> GetMovie(string id)
        {
            var Movie = await _movieRepo.GetMovieById(id);
            if (Movie == null) return null;

            var MovieModel = new MovieIndexModel { 
                Id=Movie.Id,
                Title=Movie.Title,
                Description=Movie.Description,
                Picture=Movie.Picture,
                CategoryId=Movie.CategoryId,
                Actors=Movie.Actors.Select(a=> new ActorIndexModel {
                 Id=a.Id,
                 ActorName=a.ActorName,
                 ActorPicture=a.ActorPicture
                }),
                MovieLink=Movie.MovieLink
            };

           
            return MovieModel; 
        }
        
        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] MovieCreateModel MovieModel)
        {
              var picName = saveFile(MovieModel.Picture);
              var videoName = saveFile(MovieModel.video);
             

            var movie = new Movie {
                Id = Guid.NewGuid().ToString(),
                Title=MovieModel.Title,
                Description=MovieModel.Description,
                Picture=picName,
                MovieLink=videoName,
                CategoryId=MovieModel.CategoryId,
                Actors= await getActors(MovieModel.actorsId)
            };
            await _movieRepo.Add(movie);
            return Ok();
        }
        
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] MovieUpdateModel movie)
        {
            var picName = "";
            var videoName = "";

            var ifExist = await _movieRepo.GetMovieById(movie.id);
            if(ifExist==null)
            {
                return NotFound();
            }

            if(movie.Picture!=null)
            {
                picName = saveFile(movie.Picture);
            }
            if (movie.Picture == null)
            {
                picName = ifExist.Picture;
            }
            if (movie.video!=null)
            {
                videoName = saveFile(movie.video);
            }

            if(movie.video == null)
            {
                videoName = ifExist.MovieLink;
            }
            
            var model = new Movie
            {
                Id = movie.id,
                Title = movie.Title,
                Description = movie.Description,
                Picture = picName,
                MovieLink = videoName
            };

            await _movieRepo.Update(model);

            return Ok();

        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await _movieRepo.GetMovieById(id);
            if(model==null)
            {
                return NotFound();
            }
            await _movieRepo.Delete(model);
            return Ok();

        }


        private string saveFile(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            // the oryginal Path==>  string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", picName);
             string path = Path.Combine(@"C:\Users\User\Documents\Projects\MoviesApp\MoviesAppFront\src\assets\Images", fileName);
           // string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }

       private async Task<List<Actor>> getActors(List<string> actors)
        {
            var models = new List<Actor>();
            for(var x=0;x<actors.Count;x++)
            {
                var item = await _actorRepo.GetActor(actors[x]);
                if(item!=null)
                {
                    models.Add(item);
                }
               
            }
            return models;
        }

      
    }
}
