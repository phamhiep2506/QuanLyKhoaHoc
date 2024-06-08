using KhoaHoc.Domain.Entities;

namespace KhoaHoc.Domain.Interfaces;

public interface IConfirmEmailRepository : IRepository<ConfirmEmail>
{
    public Task<bool> ConfirmEmailUseCode(int userId, string confirmCode);
}
