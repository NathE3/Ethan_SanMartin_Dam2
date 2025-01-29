using Ferraro.Models.DTOs;
using Ferraro.Models.DTOs.UserDto;
using Ferraro.Models.DTOs.DictadorDto;
using Ferraro.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ferraro.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        protected ResponseApi _reponseApi;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _reponseApi = new ResponseApi();
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "Incorrect Input", message = ModelState });
            }

            if (!_userRepository.IsUniqueUser(userRegistrationDto.UserName))
            {
                _reponseApi.StatusCode = HttpStatusCode.BadRequest;
                _reponseApi.IsSuccess = false;
                _reponseApi.ErrorMessages.Add("Username already exists");
                return BadRequest();
            }

            var newUser = await _userRepository.Register(userRegistrationDto);
            if (newUser == null)
            {
                _reponseApi.StatusCode = HttpStatusCode.BadRequest;
                _reponseApi.IsSuccess = false;
                _reponseApi.ErrorMessages.Add("Error registering the user");
                return BadRequest();
            }

            _reponseApi.StatusCode = HttpStatusCode.OK;
            _reponseApi.IsSuccess = true;
            return Ok(_reponseApi);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var responseLogin = await _userRepository.Login(userLoginDto);

            if (responseLogin.User == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _reponseApi.StatusCode = HttpStatusCode.BadRequest;
                _reponseApi.IsSuccess = false;
                _reponseApi.ErrorMessages.Add("Incorrect user and password");
                return BadRequest(_reponseApi);
            }

            _reponseApi.StatusCode = HttpStatusCode.OK;
            _reponseApi.IsSuccess = true;
            _reponseApi.Result = responseLogin;
            return Ok(_reponseApi);
        }
    }
}
