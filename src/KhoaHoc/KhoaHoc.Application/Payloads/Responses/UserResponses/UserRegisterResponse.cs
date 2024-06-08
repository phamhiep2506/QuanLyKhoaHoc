namespace KhoaHoc.Application.Payloads.Responses.UserResponses;

public class UserRegisterResponse
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
}
