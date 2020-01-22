using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace NetPlan.Persistency
{
    public class Catalog<T>
    {
        private const string ServerUrl = "http://localhost:65363";
        private static Catalog<T> _instance;
        private List<T> _catalogList;

        private Catalog()
        {
            _catalogList = new List<T>();
        }
        public static Catalog<T> Instance
        {
            get
            {
                if (_instance == null) _instance = new Catalog<T>();
                return _instance;
            }
        }

        public List<T> Cataloglist
        {
            get { return _catalogList; }
            set { _catalogList = value; }
        }




        public static List<T> Get(string url, int id = 0)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string urladd = id > 0 ? "/" + id.ToString() : "";
                    HttpResponseMessage response = client.GetAsync(url + urladd).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var status = response.Content.ReadAsStringAsync().Result;
                        List<T> rlist = new List<T>();
                        if (id > 0)
                        {
                            rlist.Add(JsonConvert.DeserializeObject<T>(status));
                        }
                        else
                        {

                            rlist = JsonConvert.DeserializeObject<List<T>>(status);

                        }
                        return rlist;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public static async Task<string> Post(string url, T objectToPost)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var serializedString = JsonConvert.SerializeObject(objectToPost);
                    StringContent content = new StringContent(serializedString, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PostAsync(url, content);

                    if (responseMessage.IsSuccessStatusCode)
                        return await responseMessage.Content.ReadAsStringAsync();

                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }




        }



        public static async Task Delete(string url)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage responseMessage = await client.DeleteAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                        await responseMessage.Content.ReadAsStringAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
        }

        public async static Task Put(string url, T objectToPut)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var serializedString = JsonConvert.SerializeObject(objectToPut);
                    StringContent content = new StringContent(serializedString, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PutAsync(url, content);
                    if (responseMessage.IsSuccessStatusCode) await responseMessage.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


    }
}
