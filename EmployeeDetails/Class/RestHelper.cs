using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeDetails.Class
{
    public  class RestHelper
    {
        
        
        private static readonly string baseURL = "https://gorest.co.in/";
       
        public static async Task<string> GetALL()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "/public-api/users"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<string> Get(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "/public-api/users/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> Post(string name, string email,string gender, string status)
        {
            var inputData = new Dictionary<string, string>
            {
                {"name", name },
                {"email", email },
                {"gender", gender },
                {"status", status },

            };
            var INPUT = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                using (HttpResponseMessage res = await client.PostAsync(baseURL + "/public-api/users/", INPUT))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<string> Put(string id, string name, string email, string gender, string status)
        {
            var inputData = new Dictionary<string, string>
            {
                {"name", name },
                {"email", email },
                {"gender", gender },
                {"status", status },
            };
            var INPUT = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");
                using (HttpResponseMessage res = await client.PutAsync(baseURL + "/public-api/users/" + id, INPUT))
               
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
       
        public static string beautifyjson(string jsonstr)
        {
            JToken parseJson = JToken.Parse(jsonstr);
            return parseJson.ToString(Formatting.Indented);
        }
      
    }
}
