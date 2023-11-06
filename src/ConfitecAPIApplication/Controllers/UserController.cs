using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConfitecAPIApplication.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(INotificationHandler notificationHandler,
        IUserService userService) : base(notificationHandler)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(UserListAllDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAllAsync();
        return Ok(users);
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(UserListAllDTO), StatusCodes.Status200OK)]
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

        var user = await _userService.CreateAsync(userRequest);
        if (user == null)
            CustomResponse();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UserUpdateDTO userRequest)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        await _userService.UpdateAsync(id, userRequest);

        return CustomResponse();
    }
}