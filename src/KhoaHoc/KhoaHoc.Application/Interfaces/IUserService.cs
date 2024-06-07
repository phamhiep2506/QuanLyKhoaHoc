using KhoaHoc.Application.Payloads.Responses.UserResponses;
using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Application.Interfaces;

public interface IUserService
{
    public Task<IResponse> GetAllUser();
}
