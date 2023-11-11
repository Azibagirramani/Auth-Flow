


namespace NgGold.Models
{

    public class Response<T>
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public T? Data { get; set; }
    }

}