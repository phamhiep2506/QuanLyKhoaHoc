using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IEmailServices;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests.UserRequests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Payloads.Responses.UserResponses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

using BCrypt.Net;

public class UserRegisterService : IUserRegisterService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IResponse _response;
    private readonly IConfirmEmailService _confirmEmailService;

    public UserRegisterService(
        IMapper mapper,
        IResponse response,
        IConfirmEmailService confirmEmailService,
        IUserRepository repository
    )
    {
        _mapper = mapper;
        _response = response;
        _confirmEmailService = confirmEmailService;
        _repository = repository;
    }

    public async Task<IResponse> CreateUserRegister(
        UserRegisterRequest userRegisterRequest
    )
    {
        User? user = await _repository.FindUser(userRegisterRequest.UserName);

        if (user == null)
        {
            User newUser = _mapper.Map<UserRegisterRequest, User>(
                userRegisterRequest
            );
            newUser.CreateTime = DateTime.Now;
            newUser.UpdateTime = DateTime.Now;
            newUser.IsActive = false;
            newUser.Password = BCrypt.HashPassword(newUser.Password);

            try
            {
                await _repository.CreateUser(newUser);
            }
            catch
            {
                return await _response.NoContent(
                    ResponseStatus.BadRequest,
                    ResponseMessage.UserRegisterFailed
                );
            }

            await _confirmEmailService.CreateConfirmEmail(newUser.Id);

            return await _response.Content(
                ResponseStatus.Created,
                ResponseMessage.UserRegisterSuccess,
                _mapper.Map<User, UserRegisterResponse>(newUser)
            );
        }

        if (user.IsActive)
        {
            return await _response.NoContent(
                ResponseStatus.Conflict,
                ResponseMessage.UserRegisterExisted
            );
        }

        await _confirmEmailService.CreateConfirmEmail(user.Id);

        return await _response.Content(
            ResponseStatus.Created,
            ResponseMessage.UserRegisterSuccess,
            _mapper.Map<User, UserRegisterResponse>(user)
        );
    }
}
