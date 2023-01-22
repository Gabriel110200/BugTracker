using Newtonsoft.Json;

namespace ProjectManagement.Models
{
    public class ErrorDetails
    {

        public int StatusCodeContext { get; internal set; }

        public string Message { get; internal set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
