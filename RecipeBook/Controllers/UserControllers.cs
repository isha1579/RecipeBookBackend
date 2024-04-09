using Microsoft.AspNetCore.Mvc;
using RecipeBook;
using Services;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly UserLoginService _userLoginService;

        public UserControllers(UserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public List<UserLogin> GetUserLogins()
        {
            return _userLoginService.GetAllUserLogins();
        }

        [HttpGet("{id}")]
        public UserLogin GetUserLogin(int id)
        {
            return _userLoginService.GetUserLoginById(id);
        }

        [HttpPost]
        public void PostUserLogin(UserLogin userLogin)
        {
            _userLoginService.AddUserLogin(userLogin);
        }

        [HttpPut("{id}")]
        public void PutUserLogin(int id, UserLogin userLogin)
        {
            _userLoginService.UpdateUserLogin(id, userLogin);
        }

        [HttpDelete("{id}")]
        public void DeleteUserLogin(int id)
        {
            _userLoginService.DeleteUserLogin(id);
        }
    }
}
