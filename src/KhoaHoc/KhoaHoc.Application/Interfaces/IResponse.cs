namespace KhoaHoc.Application.Interfaces;

public interface IResponse
{
    public Task<IResponse> NoContent(int Status, string Message);

    public Task<IResponse> Content(int Status, string Message, object Data);
}
