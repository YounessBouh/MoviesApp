
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Core.Interfaces;
using MoviesApp.Dtos.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Controllers
{
    
    public class UserController : AbstractAPIController
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("GetAll")]
        public IEnumerable<UsersListingModel> GetAll()
        {
            var model = _userRepo.getAllUsers().Select(p => new UsersListingModel {
                   Id=p.Id,
                   username=p.UserName,
                   email=p.Email,
                   Address=p.Address,
                   mobile=p.PhoneNumber
            });

            return model;
        }

        [HttpGet("{id}")]
        public async Task<UserIndexModel> GetUser(string id)
        {
            var model = await _userRepo.getById(id);
            if (model == null) return null;

            var user = new UserIndexModel { 
                  id=model.Id,
                  username=model.UserName,
                  email=model.Email,
                  mobile=model.PhoneNumber,
                  Address=model.Address
            };
            return user;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await _userRepo.getById(id);
            if (model == null) return NotFound();
           await  _userRepo.Remove(model);
            return Ok();
        }

     
    }
}
