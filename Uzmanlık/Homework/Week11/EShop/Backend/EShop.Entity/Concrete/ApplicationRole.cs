using System;
using Microsoft.AspNetCore.Identity;

namespace EShop.Entity.Concrete;

public class ApplicationRole : IdentityRole
{
    private ApplicationRole()
    {

    }
    public ApplicationRole(string description)
    {
        Description = description;
    }
    public string Description { get; set; } = string.Empty;


}
