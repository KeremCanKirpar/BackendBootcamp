using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;
using EShop.Shared.Dtos.UserDtos;

namespace EShop.Services.Abstract;

public interface IUserService
{
    Task<ResponseDto<UserDto>> GetByIdAsync(string id);
    Task<ResponseDto<NoContent>> UpdateAsync(UserUpdateDto userUpdateDto);
}