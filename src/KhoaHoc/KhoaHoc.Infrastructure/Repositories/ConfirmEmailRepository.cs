using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;

namespace KhoaHoc.Infrastructure.Repositories;

public class ConfirmEmailRepository
    : Repository<ConfirmEmail>,
        IConfirmEmailRepository
{
    private readonly IUserRepository _userRepository;
    public ConfirmEmailRepository(ApplicationDbContext context, IUserRepository userRepository)
        : base(context)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> ConfirmEmailUseCode(int userId, string confirmCode)
    {
        ConfirmEmail? confirmEmail = await GetAsync(x =>
            x.UserId == userId && x.ConfirmCode == confirmCode
        );

        if (confirmEmail == null)
        {
            return false;
        }

        if (confirmEmail.ExpiryTime < DateTime.Now)
        {
            return false;
        }

        confirmEmail.IsConfirm = true;

        await UpdateAsync(confirmEmail);

        User? user = await _userRepository.GetAsync(x => x.Id == userId);

        if (user != null)
        {
            user.IsActive = true;
            await _userRepository.UpdateAsync(user);
        }

        return true;
    }
}
