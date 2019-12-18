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
        private T _single;

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
        //properties
        public T Single(int id)
        {
            return _single;
        }
        public List<T> Get()
        {
            return _catalogList;
        }
        //methods

        // Henter en enkelt række ud hvis man sender et id med som andet parameter, returner altid som List
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
                    string urladd = id>0?"/"+id.ToString():"";
                    HttpResponseMessage response = client.GetAsync(url+urladd).Result;
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

                    return new List<T>();
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
       

    }
}
