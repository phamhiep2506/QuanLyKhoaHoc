using AutoMapper;
using KhoaHoc.Application.Helpers;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Payloads.Requests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services;

using BCrypt.Net;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
    private readonly IMapper _mapper;
    private readonly IResponse _response;

    public UserService(
        IRepository<User> userRepository,
        IRepository<ConfirmEmail> confirmEmailRepository,
        IMapper mapper,
        IResponse response
    )
    {
        _userRepository = userRepository;
        _confirmEmailRepository = confirmEmailRepository;
        _mapper = mapper;
        _response = response;
    }

    public async Task<IResponse> UserRegister(
        UserRegisterRequest userRegisterRequest
    )
    {
        if (
            await _userRepository.AnyAsync(x =>
                x.UserName == userRegisterRequest.UserName
            )
        )
        {
            return await _response.NoContent(
                ResponseStatus.Conflict,
                ResponseMessage.UserRegisterExisted
            );
        }

        User user = _mapper.Map<UserRegisterRequest, User>(userRegisterRequest);
        user.CreateTime = DateTime.Now;
        user.UpdateTime = DateTime.Now;
        user.IsActive = false;
        user.Password = BCrypt.HashPassword(user.Password);

        try
        {
            await _userRepository.AddAsync(user);
        }
        catch
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserRegisterFailed
            );
        }

        // Crate table confirm Email when new create a user
        ConfirmEmail confirmEmail = new ConfirmEmail();
        confirmEmail.UserId = user.Id;
        confirmEmail.ConfirmCode = RandomEmailConfirmCode.RandomString(5);
        confirmEmail.ExpiryTime = DateTime.Now;
        confirmEmail.IsConfirm = false;

        await _confirmEmailRepository.AddAsync(confirmEmail);

        return await _response.NoContent(
            ResponseStatus.Created,
            ResponseMessage.UserRegisterSuccess
        );
    }
}
