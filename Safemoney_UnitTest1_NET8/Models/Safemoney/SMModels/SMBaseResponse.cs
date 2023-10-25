namespace Client.Models.Safemoney.SMModels
{
    public class SMBaseResponse<T>
    {
        public T? Content { get; set; }
        public bool IsSuccess { get; private set; }
        public SMError? Error { get; private set; }

        public SMBaseResponse(T content)
        {
            Content = content;
            IsSuccess = true;
        }

        public SMBaseResponse(SMError error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static SMBaseResponse<T> CreateSuccessResponse(T content)
        {
            return new SMBaseResponse<T>(content);
        }

        public static SMBaseResponse<T> CreateErrorResponse(SMError error)
        {
            return new SMBaseResponse<T>(error);
        }
    }

}
