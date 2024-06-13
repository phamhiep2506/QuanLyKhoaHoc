using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IJwtServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

public class UserUpdateService : IUserUpdateService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtGetClaimsService _jwtGetClaimsService;
    private readonly IResponse _response;

    public UserUpdateService(
        IMapper mapper,
        IUserRepository userRepository,
        IJwtGetClaimsService jwtGetClaimsService,
        IResponse response
    )
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _jwtGetClaimsService = jwtGetClaimsService;
        _response = response;
    }

    public async Task<IResponse> UpdateInfo(
        int userId,
        UserUpdateRequest userUpdateRequest
    )
    {
        User? user = await _userRepository.FindByIdAsync(userId);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserNotExisted
            );
        }

        _mapper.Map(userUpdateRequest, user);

        await _userRepository.UpdateUser(user);

        return await _response.NoContent(
            ResponseStatus.Success,
            ResponseMessage.UserUpdateSuccess
        );
    }
}
