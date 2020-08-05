using Newtonsoft.Json;

namespace ControleVeiculos.Application.Common.Responses
{
    public class SuccessResponse
    {
        public SuccessResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { message = Message });
        }
    }
}
