﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using AutoMapper;
using static DTO.UserDTO;



namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices service;
        IMapper  _mapper;
        ILogger<UsersController> _logger;

        public UsersController(IUserServices service, IMapper _mapper, ILogger<UsersController> logger)
        {
            this.service = service;
            this._mapper = _mapper;
            _logger = logger;
        }
       

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
       
        [HttpPost]
        public async Task<ActionResult<ReturnPostUserDTO>> Post([FromBody] AddUserDTO user)
        {   User newUser= _mapper.Map<AddUserDTO, User> (user);
            newUser = await service.Post(newUser);
            if (newUser != null)
            {
                _logger.LogInformation($"User name: {user.Email} Name: {user.FirstName} {user.LastName}");

                return Ok(_mapper.Map<User, ReturnPostUserDTO>(newUser));
            }
            return NoContent();


        }

        //[HttpPost("login")]
        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult<ReturnLoginUserDTO>> Login([FromQuery] string email, [FromQuery] string password)
        {
            User user=await service.Login(email, password);
            if (user!=null)
            {
                return Ok(_mapper.Map<User, ReturnLoginUserDTO>(user));
            }

                       
            return NoContent();



        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User> >Put(int id, [FromBody] AddUserDTO user)

        {
           User updateUser = _mapper.Map<AddUserDTO, User>(user);
            updateUser =await service.Put(id, updateUser);
            if (updateUser != null)
            {
                return Ok(_mapper.Map<User, ReturnPostUserDTO>(updateUser));
            }




            return NoContent();


            
            
            
        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("password")]
      
        public IActionResult cheackPassword([FromBody] string password)
        {
            int result = service.cheackPassword(password);
            return(result<3) ?
                   BadRequest(result):
            Ok( result);
        }



        


        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await service.GetUserByEmail(email);

            if (user != null)
            {
                return Ok(_mapper.Map<User, ReturnPostUserDTO>(user));
            }
            return Ok(user);
        }
    }
    }

