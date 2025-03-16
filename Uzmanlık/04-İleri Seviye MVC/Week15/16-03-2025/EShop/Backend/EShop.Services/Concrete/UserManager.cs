using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;
using EShop.Shared.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Concrete;

public class UserManager : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IImageService _imageManager;

    public UserManager(UserManager<ApplicationUser> userManager, IImageService imageManager)
    {
        _userManager = userManager;
        _imageManager = imageManager;
    }

    public async Task<ResponseDto<UserDto>> GetByIdAsync(string id)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
            return ResponseDto<UserDto>.Fail("Kullanıcı bulunamadı.", StatusCodes.Status404NotFound);

        var roles = await _userManager.GetRolesAsync(user);

        var userDto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            Roles = roles.ToList()
        };

        return ResponseDto<UserDto>.Success(userDto, StatusCodes.Status200OK);
    }

    public async Task<ResponseDto<NoContent>> UpdateAsync(UserUpdateDto userUpdateDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userUpdateDto.Id);
        if (user == null)
            return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı.", StatusCodes.Status404NotFound);

        user.FirstName = userUpdateDto.FirstName;
        user.LastName = userUpdateDto.LastName;
        user.Email = userUpdateDto.Email;
        user.PhoneNumber = userUpdateDto.PhoneNumber;


        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return ResponseDto<NoContent>.Fail(result.Errors.First().Description, StatusCodes.Status400BadRequest);

        return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
    }
}