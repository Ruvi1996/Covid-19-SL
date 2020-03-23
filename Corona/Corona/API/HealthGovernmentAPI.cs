using Corona.Helpers;
using Corona.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Corona.API
{
    public class HealthGovernmentAPI
    {
        public async Task<HealthGovAPIResponse> GetCoronaData()
        {
            string url = "/api/get-current-statistical";

            using (HttpClient httpClient = new HttpClient())
            {
                HealthGovAPIResponse data = new HealthGovAPIResponse();
                try
                {
                    httpClient.BaseAddress = new Uri(ConstantsHelper.BaseUrl);
                    HttpResponseMessage result = await httpClient.GetAsync(url);
                    string response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<HealthGovAPIResponse>(response);

                    if (result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.OK)
                    {
                        return data;
                    }

                    return null;
                }

                catch (Exception exp)
                {
                    return null;
                }
            }
        }
    }
}
