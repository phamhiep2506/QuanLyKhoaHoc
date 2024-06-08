using KhoaHoc.Domain.Entities;
using KhoaHoc.Domain.Interfaces;
using KhoaHoc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KhoaHoc.Infrastructure.Repositories;

public class ConfirmEmailRepository
    : Repository<ConfirmEmail>,
        IConfirmEmailRepository
{
    private readonly ApplicationDbContext _context;

    public ConfirmEmailRepository(ApplicationDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<bool> ConfirmEmailUseCode(int userId, string confirmCode)
    {
        ConfirmEmail? confirmEmail = await Query(x =>
                x.UserId == userId && x.ConfirmCode == confirmCode
            )
            .Include(x => x.User)
            .SingleOrDefaultAsync();

        if (confirmEmail == null)
        {
            return false;
        }

        if (confirmEmail.ExpiryTime < DateTime.Now)
        {
            return false;
        }

        confirmEmail.IsConfirm = true;

        if (confirmEmail.User != null)
        {
            confirmEmail.User.IsActive = true;
        }

        await UpdateAsync(confirmEmail);

        return true;
    }
}
