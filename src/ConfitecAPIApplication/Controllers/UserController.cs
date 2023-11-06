using ConfitecAPIApplication.Interfaces;
using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Services;
using ConfitecAPIBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConfitecAPIApplication.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IUserApplicationService _userApplicationService;

    public UserController(INotificationHandler notificationHandler,
        IUserService userService, IUserApplicationService userApplicationService) : base(notificationHandler)
    {
        _userService = userService;
        _userApplicationService = userApplicationService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userApplicationService.ListAllAsync();
        return Ok(users);
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var users = await _userService.ListByIdAsync(id);

        if (users == null)
        {
            return NotFound();
        }

        return CustomResponse(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDTO userRequest)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        //var user = await _userService.CreateAsync(userRequest);
        //if (user == null)
        //    CustomResponse();

        return CreatedAtAction(nameof(GetById), userRequest);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UserUpdateDTO userRequest)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        //await _userService.UpdateAsync(userRequest);

        return CustomResponse();
    }
}