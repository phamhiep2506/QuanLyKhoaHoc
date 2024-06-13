namespace KhoaHoc.Application.Interfaces.IUserServices;

public interface IUserGetService
{
    public Task<IResponse> GetInfo(int userId);
}
