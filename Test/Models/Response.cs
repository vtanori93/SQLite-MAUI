namespace Test.Models
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; } = string.Empty; 
    }
}
