using ASP.NETCoreIdentityCustom.Areas.Identity.Data;

namespace ASP.NETCoreIdentityCustom.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string Id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
