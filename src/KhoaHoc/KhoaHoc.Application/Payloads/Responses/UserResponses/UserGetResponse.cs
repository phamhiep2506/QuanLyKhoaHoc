namespace KhoaHoc.Application.Payloads.Responses.UserResponses;

public class UserGetResponse
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? Address { get; set; }
}
