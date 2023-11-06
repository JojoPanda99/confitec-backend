using ConfitecAPIApplication.DTOs.User;
using ConfitecAPIApplication.Interfaces;
using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecAPIApplication.Controllers;

public class UserController : BaseController
{
    private readonly IUserApplicationService _userApplicationService;

    public UserController(INotificationHandler notificationHandler,
        IUserApplicationService userApplicationService) : base(notificationHandler)
    {
        _userApplicationService = userApplicationService;
    }

    //<summary> CRUD: Get all users </summary>
    //<response code="200"> Users found </response>
    [HttpGet]
    [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userApplicationService.ListAllAsync();

        return CustomResponse(users);
    }

    //<summary> Get a user by id </summary>
    //<param name="id"> User id </param>
    //<response code="200"> User found </response>
    //<response code="404"> User not found </response>
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

    //<summary> Create a new user </summary>
    //<param name="userRequestDto"> User data </param>
    //<response code="201"> User created </response>
    //<response code="400"> Invalid data </response>
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

    //<summary> Update a user by id </summary>
    //<param name="id"> User id </param>
    //<param name="userRequest"> User data </param>
    //<response code="200"> User updated </response>
    //<response code="400"> Invalid data </response>
    //<response code="404"> User not found </response>
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

    //<summary> Delete a user by id </summary>
    //<param name="id"> User id </param>
    //<response code="204"> User deleted </response>
    //<response code="404"> User not found </response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _userApplicationService.DeleteAsync(id);

        if (HasNotification())
            return CustomResponse();

        return NoContent();
    }
}