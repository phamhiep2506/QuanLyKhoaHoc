using AutoMapper;
using KhoaHoc.Application.Payloads.Requests;
using KhoaHoc.Application.Payloads.Requests.UserRequests;
using KhoaHoc.Application.Payloads.Responses.UserResponses;
using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Application.Payloads.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegisterRequest, User>();
        CreateMap<User, UserRegisterResponse>();
        CreateMap<UserUpdateRequest, User>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null)
            );
        CreateMap<User, UserGetResponse>();
    }
}
