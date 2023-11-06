using System.ComponentModel.DataAnnotations;
using ConfitecAPIBusiness.Models;

namespace ConfitecAPIApplication.DTOs.User;

public class CreateUserRequestDTO
{
    [Required] public string Name { get; set; }

    [Required] public string Surname { get; set; }

    [Required] public DateTime BirthDate { get; set; }

    [Required] public string Email { get; set; }

    [Required]
    public EducationEnum Education { get; set; }
}