
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Entities;
using MoviesApp.Core.Interfaces;
using MoviesApp.Dtos.Actor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MoviesApp.Controllers
{
    [Authorize]
    public class ActorController : AbstractAPIController
    {
        private readonly IActorRepo _actorRepo;
        public ActorController(IActorRepo actorRepo)
        {
            _actorRepo = actorRepo;
        }

        [HttpGet("Actors")]
        public IEnumerable<ActorListingModel> Actors()
        {
            var actors = _actorRepo.GetActors().Select(a=>new ActorListingModel { 
              Id=a.Id,
              ActorName=a.ActorName,
              ActorPicture=a.ActorPicture
            });
            return actors;
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ActorCreateModel actorModel)
        {
            var picName = saveFile(actorModel.ActorPicture);

            var model = new Actor {
             Id=Guid.NewGuid().ToString(),
             ActorName=actorModel.ActorName,
             ActorPicture=picName
            };

            await _actorRepo.Add(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await _actorRepo.GetActor(id);
            if(model==null)
            {
                return NotFound();
            }

            await _actorRepo.Delete(model);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] ActorUpdateModel actorModel)
        {
            var model = await _actorRepo.GetActor(actorModel.Id);
            if(model==null)
            {
                return NotFound();
            }

            var actor = new Actor { 
             Id=actorModel.Id,
             ActorName=actorModel.ActorName,
             ActorPicture=actorModel.ActorPicture
            };

            await _actorRepo.Update(actor);
            return Ok(actor);
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
    }
}
