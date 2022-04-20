using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rappro.Data;

namespace ASP.NETCoreIdentityCustom.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public virtual ICollection<Rapprochement> Rapprochements { get; set; }
}

public class ApplicationRole : IdentityRole
{

}