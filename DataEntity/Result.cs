namespace DataEntity
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Result Success(string message = "")
        {
            return new Result() { IsSuccess = true, Message = message };
        }

        public static Result Error(string message = "")
        {
            return new Result() { IsSuccess = false, Message = message };
        }
    }
}
