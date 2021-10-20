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
            this.Result = Data;

        }

        public Response(int StatusCode, string Message, dynamic Data)
        {
            this.StatusCode = StatusCode;
            this.Result = Data;
            this.Message = Message;
        }

        public int StatusCode { get; set; }
        public string Message{ get; set; }
        public dynamic Result { get; set; }
    }
}
