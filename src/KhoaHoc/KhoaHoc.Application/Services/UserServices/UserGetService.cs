using AutoMapper;
using KhoaHoc.Application.Interfaces;
using KhoaHoc.Application.Interfaces.IUserServices;
using KhoaHoc.Application.Payloads.Responses;
using KhoaHoc.Application.Payloads.Responses.UserResponses;
using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;

namespace KhoaHoc.Application.Services.UserServices;

public class UserGetService : IUserGetService
{
    private readonly IUserRepository _userRepository;
    private readonly IResponse _response;
    private readonly IMapper _mapper;

    public UserGetService(
        IUserRepository userRepository,
        IResponse response,
        IMapper mapper
    )
    {
        _userRepository = userRepository;
        _response = response;
        _mapper = mapper;
    }

    public async Task<IResponse> GetInfo(int userId)
    {
        User? user = await _userRepository.FindByIdAsync(userId);

        if (user == null)
        {
            return await _response.NoContent(
                ResponseStatus.BadRequest,
                ResponseMessage.UserNotExisted
            );
        }

        return await _response.Content(
            ResponseStatus.Success,
            ResponseMessage.UserGetSuccess,
            _mapper.Map<User, UserGetResponse>(user)
        );
    }
}
