using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WepApi.Converter;
using WepApi.Model.User;

namespace WepApi.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;

        }

        [HttpPost]
        public IActionResult Post( UserRequestModel model,CancellationToken cancellationToken)
        {
            var result= _userservice.UserGetAsync(UserConverter.ToUserRequestDTO(model), cancellationToken);
            return Ok();
        }
    }
}
