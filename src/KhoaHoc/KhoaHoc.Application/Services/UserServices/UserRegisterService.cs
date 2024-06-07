using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Requests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services;

using BCrypt.Net;
using KhoaHoc.Application.Interfaces.IEmailServices;

public class UserRegisterService : IUserRegisterService
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;
    private readonly IResponse _response;
    private readonly IConfirmEmailService _confirmEmailService;

    public UserRegisterService(
        IRepository<User> repository,
        IMapper mapper,
        IResponse response,
        IConfirmEmailService confirmEmailService
    )
    {
        _repository = repository;
        _mapper = mapper;
        _response = response;
        _confirmEmailService = confirmEmailService;
    }

    public async Task<IResponse> CreateUserRegister(
        UserRegisterRequest userRegisterRequest
    )
    {
        if (
            await _repository.AnyAsync(x =>
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
            await _repository.AddAsync(user);
        }
        catch
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserRegisterFailed
            );
        }

        await _confirmEmailService.CreateConfirmEmail(user.Id);

        return await _response.NoContent(
            ResponseStatus.Created,
            ResponseMessage.UserRegisterSuccess
        );
    }
}
