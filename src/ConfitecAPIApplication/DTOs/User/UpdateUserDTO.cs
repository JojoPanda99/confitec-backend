using ConfitecAPIBusiness.Models;

namespace ConfitecAPIApplication.DTOs.User;

public class UpdateUserDTO
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Email { get; set; }

    public EducationEnum? Education { get; set; }
}