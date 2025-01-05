using System;
using EShop.Shared.ComplexTypes;
using Microsoft.AspNetCore.Identity;

namespace EShop.Entity.Concrete;

public class ApplicationUser : IdentityUser
{
    private ApplicationUser()
    {

    }
    public ApplicationUser(string firstName, string lastName, DateTime dateOfBirth, GenderType gender)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderType Gender { get; set; }
}
