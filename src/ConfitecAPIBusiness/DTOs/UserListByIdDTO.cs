using ConfitecAPIBusiness.Models;

namespace ConfitecAPIBusiness.DTO;

public class UserListByIdDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public Education Education { get; set; }
}