namespace Domain
{
    public class Result
    {
        public string Error { get; }
        public bool IsInError { get; }

        private Result(string error)
        {
            this.Error = error;
            this.IsInError = error != null;
        }

        public static Result Failed(string message)
        {
            return new Result(message);
        }

        public static Result Success()
        {
            return new Result(null);
        }
    }
}