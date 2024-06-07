namespace KhoaHoc.Application.Interfaces;

public interface IResponse
{
    public IResponse NoContent(int Status, string Message);

    public IResponse Content(int Status, string Message, object Data);
}