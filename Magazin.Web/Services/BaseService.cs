using Magazin.Web.Models;
using Magazin.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Magazin.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO responseModel { get; set; }

        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDTO();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client=httpClient.CreateClient("MagazinAPI");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Headers.Add("Accept", "application/json");
                httpRequestMessage.RequestUri=new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data is not null)
                {
                    httpRequestMessage.Content = new StringContent
                        (JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case CD.ApiType.POST:
                        httpRequestMessage.Method=HttpMethod.Post;
                        break;
                    case CD.ApiType.PUT:
                        httpRequestMessage.Method = HttpMethod.Put;
                        break;
                    case CD.ApiType.DELETE:
                        httpRequestMessage.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequestMessage.Method=HttpMethod.Get;
                        break;
                }
                apiResponse=await client.SendAsync(httpRequestMessage);

                string apiContent=await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO= JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;
            }
            catch(Exception ex)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "Error!",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res=JsonConvert.SerializeObject(dto);
                var apiResponseDTO=JsonConvert.DeserializeObject<T>(res);
                return apiResponseDTO;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
