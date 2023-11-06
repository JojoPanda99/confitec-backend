using ConfitecAPIBusiness.Models;

namespace ConfitecAPIApplication.Interfaces;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public EducationEnum Education { get; set; }
}