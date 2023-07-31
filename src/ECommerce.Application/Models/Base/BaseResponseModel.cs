namespace ECommerce.Application.Models.Base;

public class BaseResponseModel
{
    public string ErrorMessage { get; set; } = string.Empty;
    public string Message { get; set; } = String.Empty;
    public bool IsSuccess { get; set; } = true;
}
