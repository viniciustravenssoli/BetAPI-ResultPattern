namespace Bet.Application.Commun;
public class AppError
{
    public string ErrorCode { get; }
    public string ErrorMessage { get; }

    public AppError(string errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }
}

