namespace Client.Models.SMModels
{
    public class SMResponse<T>
    {
        public T Content { get; set; }
        public bool IsSuccess { get; private set; }
        public SMError Error { get; private set; }

        public SMResponse(T content)
        {
            Content = content;
            IsSuccess = true;
        }

        public SMResponse(SMError error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static SMResponse<T> CreateSuccessResponse(T content)
        {
            return new SMResponse<T>(content);
        }

        public static SMResponse<T> CreateErrorResponse(SMError error)
        {
            return new SMResponse<T>(error);
        }
    }

}
