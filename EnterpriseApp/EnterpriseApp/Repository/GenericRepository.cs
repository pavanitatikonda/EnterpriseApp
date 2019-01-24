using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Repository
{
    public class GenericRepository
    //: IGenericRepository
    {
        //public async Task<T> GetAsync<T>(string uri, string authToken = "")
        //{
        //    try
        //    {
        //        HttpClient httpClient = CreateHttpClient(uri);

        //        HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            string message = await responseMessage.Content.ReadAsStringAsync();

        //            var result = JsonConvert.DeserializeObject<T>(message);

        //    return result;
        //}

        ////error 
        //var content = await responseMessage.Content.ReadAsStringAsync();

        //if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
        //    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //{
        //    throw new HttpRequestException();
        //    // throw new ServiceAuthenticationException(content);
        //}

        //throw new HttpRequestException();
        //// throw new HttpRequestExceptionEx(responseMessage.StatusCode, content);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw;
        //    }

        //}

        ////PostAsnc 
        //PutAysnc 
        //DeleteAsync


        //        private HttpClient CreateHttpClient(string authToken)
        //        {
        //            var httpClient = new HttpClient();

        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            if (!string.IsNullOrEmpty(authToken))
        //            {
        //                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        //            }

        //            return httpClient;
        //        }
    }
}
