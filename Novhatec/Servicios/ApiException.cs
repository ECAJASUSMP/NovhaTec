using System.Net;

namespace Novhatec.Servicios
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        public ApiException(HttpStatusCode statusCode, string content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public ApiException(string? message) : base(message)
        {
        }
    }
}
