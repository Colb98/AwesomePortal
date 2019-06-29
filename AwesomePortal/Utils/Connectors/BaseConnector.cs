using AwesomePortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Utils.Connectors
{

    class BaseConnector
    {
        protected static HttpClient client = new HttpClient();
        private static BaseConnector instance;
        private BaseConnector()
        {
            SetUpClient();
        }

        public static BaseConnector getInstance()
        {
            if (instance == null)
                instance = new BaseConnector();
            return instance;
        }
        protected async Task<Object> PostObjectAsync(string path, Object o)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, o);
            response.EnsureSuccessStatusCode();
            Object ans = null;
            if (response.IsSuccessStatusCode)
            {
                ans = await response.Content.ReadAsAsync<Object>();
            }
            return ans;
        }

        protected async Task<Object> GetObjectAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            Object o = null;
            if (response.IsSuccessStatusCode)
            {
                o = await response.Content.ReadAsAsync<Object>();
            }
            return o;
        }

        protected async Task<Object> PostListObjectAsync(string path, List<Object> o)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, o);
            response.EnsureSuccessStatusCode();
            Object ans = null;
            if (response.IsSuccessStatusCode)
            {
                ans = await response.Content.ReadAsAsync<Object>();
            }
            return ans;
        }

        protected async Task<List<Object>> GetListObjectAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            List<Object> o = null;
            if (response.IsSuccessStatusCode)
            {
                o = await response.Content.ReadAsAsync<List<Object>>();
            }
            return o;
        }

        // Samples
        public async Task<Object> GetObject(string path)
        {
            try
            {
                // Get the product
                Object o = await GetObjectAsync(path);
                return o;
            }
            catch (Exception e)
            {
                LogHelper.Log(e.Message);
            }
            return null;
        }

        public async Task<Object> PostObject(string path, Object o)
        {
            try
            {
                // Get the product
                Object ans = await PostObjectAsync(path, o);
                return ans;
            }
            catch (Exception e)
            {
                LogHelper.Log(e.Message);
            }
            return null;
        }

        public async Task<List<Object>> GetListObject(string path)
        {
            try
            {
                // Get the product
                List<Object> o = await GetListObjectAsync(path);
                return o;
            }
            catch (Exception e)
            {
                LogHelper.Log(e.Message);
            }
            return null;
        }


        protected static void SetUpClient()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
