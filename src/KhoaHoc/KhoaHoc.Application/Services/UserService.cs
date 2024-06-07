using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Payloads.Responses.UserResponses;
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

    public async Task<IResponse> GetAllUser()
    {
        List<User> users = await _repository.GetAllAsync();
        return _response.Content(
            ResponseStatus.Success,
            ResponseMessage.RegisterSuccess,
            _mapper.Map<List<User>, List<UserRegisterResponse>>(users)
        );
    }
}
