using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Payloads.Requests;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository<User> _repository;
    private readonly IMapper _mapper;
    private readonly IResponse _response;

    public UserService(
        IUserRepository<User> repository,
        IMapper mapper,
        IResponse response
    )
    {
        _repository = repository;
        _mapper = mapper;
        _response = response;
    }

    public async Task<IResponse> UserRegister(
        UserRegisterRequest userRegisterRequest
    )
    {
        if(await _repository.AnyAsync(x => x.UserName == userRegisterRequest.UserName))
        {
            return await _response.NoContent(
                ResponseStatus.Conflict,
                ResponseMessage.UserRegisterExisted
            );
        }

        User user = _mapper.Map<UserRegisterRequest, User>(userRegisterRequest);

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

        return await _response.NoContent(
            ResponseStatus.Created,
            ResponseMessage.UserRegisterSuccess
        );
    }
}
