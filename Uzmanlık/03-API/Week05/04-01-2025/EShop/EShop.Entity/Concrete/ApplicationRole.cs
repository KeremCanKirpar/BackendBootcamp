using System;
using Microsoft.AspNetCore.Identity;

namespace EShop.Entity.Concrete;

public class ApplicationRole: IdentityRole
{
    public ApplicationRole()
    {
        
    }
    public ApplicationRole(string descripiton)
    {
        Descripiton = descripiton;
    }
    public string Descripiton { get; set; }=string.Empty;

   
}
