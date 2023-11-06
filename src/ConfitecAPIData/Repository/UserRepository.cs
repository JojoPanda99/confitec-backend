using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Repositories;
using ConfitecAPIBusiness.Models;
using ConfitecAPIData.Context;
using Microsoft.EntityFrameworkCore;

namespace ConfitecAPIData.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ConfitecApiContext context) : base(context)
    {
    }
}