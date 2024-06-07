using System.Text.Json.Serialization;
using KhoaHoc.Application.Interfaces;

namespace KhoaHoc.Application.Payloads.Responses;

public class Response : IResponse
{
    public int Status { get; set; }
    public string? Message { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Data { get; set; }

    public IResponse NoContent(int Status, string Message)
    {
        this.Status = Status;
        this.Message = Message;
        return this;
    }

    public IResponse Content(int Status, string Message, object Data)
    {
        this.Status = Status;
        this.Message = Message;
        this.Data = Data;
        return this;
    }
}