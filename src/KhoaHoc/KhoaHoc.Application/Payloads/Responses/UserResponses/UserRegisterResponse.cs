namespace KhoaHoc.Application.Payloads.Responses.UserResponses;

public class UserRegisterResponse
{
    public int id { get; set; }
    public string? UserName { get; set; }
    public DateTime CreateTime { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
    public DateTime UpdateTime { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public string? Address { get; set; }
    public int DistrictId { get; set; }
    public int ProvinceId { get; set; }
    public int CertificateId { get; set; }
    public int WardId { get; set; }
}
