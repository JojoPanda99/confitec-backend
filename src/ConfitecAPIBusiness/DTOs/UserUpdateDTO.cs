using ConfitecAPIBusiness.Models;

namespace ConfitecAPIBusiness.DTO;

public class UserUpdateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public Education Education { get; set; }
}