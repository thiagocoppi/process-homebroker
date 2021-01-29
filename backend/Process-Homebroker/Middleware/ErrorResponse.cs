using Microsoft.AspNetCore.Mvc;

namespace Process_Homebroker.Middleware
{
    public class ErrorResponse : ActionResult
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public string Stacktrance { get; set; }
    }
}