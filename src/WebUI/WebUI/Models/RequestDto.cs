using System.Net.Mime;
using System.Security.AccessControl;
using static WebUI.Utilities.SD;

namespace WebUI.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
