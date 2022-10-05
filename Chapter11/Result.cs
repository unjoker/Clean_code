namespace Chapter11
{
    public class Result
    {
        private Result(bool success, string error="")
        {
            IsSuccess = success;
            Error = error;
        }
        
        public bool IsSuccess { get; }
        public string Error { get; }

        public static Result Success() => new Result(success:true);
        public static Result Fail(string msg) => new Result(success: false, error: msg);
    }
}