namespace ConfitecAPIBusiness.Models;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public EducationEnum Education { get; set; }
}