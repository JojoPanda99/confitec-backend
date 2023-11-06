using ConfitecAPIApplication.Interfaces;

namespace ConfitecAPIBusiness.DTO;

public class UserByIdDTO : UserDTO
{
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
}