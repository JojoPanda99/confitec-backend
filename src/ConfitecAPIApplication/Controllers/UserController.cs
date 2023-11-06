using ConfitecAPIApplication.DTOs.User;
using ConfitecAPIApplication.Interfaces;
using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
    [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userApplicationService.ListAllAsync();
        return CustomResponse(users);
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(UserByIdDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var users = await _userApplicationService.ListByIdAsync(id);
        if (users != null)
            return CustomResponse(users);
        return CustomResponse();
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponseDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync(CreateUserRequestDTO userRequestDto)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);

        var user = await _userApplicationService.CreateAsync(userRequestDto);

        if (user != null)
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);

        return CustomResponse();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(UpdateUserDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UpdateUserDTO userRequest)
    {
        if (!ModelState.IsValid)
            return CustomResponse(ModelState);
        userRequest.Id = id;
        await _userApplicationService.UpdateAsync(userRequest);

        return CustomResponse();
    }
}