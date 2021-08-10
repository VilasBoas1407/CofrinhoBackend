namespace Domain.Utils
{
    public class Response
    {
        public Response(int StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
        }

        public Response(int StatusCode, dynamic Data)
        {
            this.StatusCode = StatusCode;
            this.Data = Data;

        }

        public int StatusCode { get; set; }
        public string Message{ get; set; }
        public dynamic Data { get; set; }
    }
}
