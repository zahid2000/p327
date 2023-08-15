using Newtonsoft.Json;

namespace Core.Entities.Concrete;

public class ErrorDetail
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
