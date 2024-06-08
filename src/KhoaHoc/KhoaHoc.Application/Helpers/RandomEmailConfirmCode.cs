namespace KhoaHoc.Application.Helpers;

public static class RandomEmailConfirmCode
{
    private static Random random = new Random();

    public static string RandomCode(int length)
    {
        string code = string.Empty;

        for (int i = 0; i < length; i++)
        {
            code = String.Concat(code, random.Next(10).ToString());
        }

        return code;
    }
}
